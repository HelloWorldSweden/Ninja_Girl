using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public Rigidbody2D myRigidBody;


    private AnimController _myPlayerAnimation;
    private SpriteRenderer _mySpriteRenderer;
    private bool resetJumpNeeded = false;
    private IUseable useable;
    private PlayerSprite _plSprite;

    public ParticleSystem myParticle;
    public int Health
    {
        get; set;
    }

    // ##### Deklarera en property här ##### //
    
   

    // ############## //

    [SerializeField]
    private bool grounded = false;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField] private int coins;
    [SerializeField] private int crystals;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] float _climbSpeed;


    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        _myPlayerAnimation = GetComponent<AnimController>(); //på samma objekt.
        _mySpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _plSprite = GetComponentInChildren<PlayerSprite>();

        // ############# Sätt OnLadder property to false ############### //
        

        // ################################################ //

        Health = 4;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        // Debug.DrawRay(transform.position, Vector2.down, Color.black); //To see the Raycast.
        if (Input.GetKeyDown(KeyCode.L))
        {
            Use();
        }
    }


    void Movement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Flip(moveX); //Flip Metod.

        myRigidBody.velocity = new Vector2((moveX * speed), myRigidBody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() == true)
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
            StartCoroutine(resetJumpRoutine());
            _myPlayerAnimation.Jump();
        }

        if (Input.GetKeyDown(KeyCode.F) && IsGrounded() == true)
        {
            _myPlayerAnimation.Attack();
        }

        // ######## For movement on the ladder ############# //
        

        
        
        // ##############################   //



        _myPlayerAnimation.Move(moveX);
    }
















    public void AddCoins(int amount)
    {
        coins += amount;
        UIManager.Instance.ShowCoins(coins);
    }

    public void AddCrystal(int amount)
    {
        crystals += amount;
        UIManager.Instance.ShowCrystals(crystals);
    }

    void Use()
    {
        if (useable != null)
        {
            useable.Use();
        }
    }

    

    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1.0f, 1 << 8);

        if (hitInfo.collider != null)
        {
            grounded = true;

            if (resetJumpNeeded == false)
            {
                return true;
            }

        }
        return false;
        //Debug.DrawRay(transform.position, Vector2.down, Color.black); //To see the Raycast.
    }

    void Flip(float leftorright)
    {
        if (leftorright < 0)
        {
            _mySpriteRenderer.flipX = true;

        }
        else if (leftorright > 0)
        {
            _mySpriteRenderer.flipX = false;
        }
    }

    public void Damage()
    {
        if (Health <= 1)
        {
            //return; //Do Nothing.
            print("Health Less than 1");
            UIManager.Instance.Restarting(true);
            Destroy(this.gameObject);
        }
        Debug.Log("Player got injured");
        Health--;
        UIManager.Instance.UpdateLives(Health);

    }

    IEnumerator resetJumpRoutine()
    {
        resetJumpNeeded = true;
        yield return new WaitForSeconds(0.1f);
        resetJumpNeeded = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Useable")
        {
            useable = other.GetComponent<IUseable>();

        }

        if (other.tag == "Next")
        {
            UIManager.Instance.NextLevel(true);
        }
    }


    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Useable")
        {
            useable = null;
        }
    }
}
