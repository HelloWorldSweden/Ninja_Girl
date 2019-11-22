using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    // """"""""""""""""""""" HÄR DEKLARERAR NI EN PROPERTY """""""""""""""""""""" //
    

    // """"""""""""""""""""""""""""  """""""""""""""""""""""""""""""""""" //

    public float speed = 5;
    private Player pl;
    private Rigidbody2D rb;
    private PlayerSprite playerSprite;


    // Start is called before the first frame update
    void Start()
    {
        // """""""""""""""""""""" HÄR SÄTTER VI VÅR PROPERTY TILL FALSE """""""""""""""""""""""""""" //
        

        // """""""""""""""""""""""""""""""""""""""""""""  """""""""""""""""""""""""""""""""""""" //

        pl = GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponentInChildren<PlayerSprite>();

    }


    // Update is called once per frame
    void Update()
    {

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // """"""""""""""""""""""""" HÄR SKRIVER VI EN IF SATS """"""""""""""""""""""""""""""""""""" // 
        

        // """""""""""""""""""""""""""""""""""""""""  """""""""""""""""""""""""""""""""""""""""" //
    }
}
