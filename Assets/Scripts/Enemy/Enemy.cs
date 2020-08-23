using UnityEngine;
using UnityEngine.UI;

namespace NinjaGirl
{
    public class Enemy : MonoBehaviour
    {
        private SpriteRenderer sr;
        public SpriteRenderer SR
        {
            get
            {
                if (sr == null)
                {
                    sr = GetComponentInChildren<SpriteRenderer>();
                }
                return sr;
            }
        }

        private Animator anim;
        public Animator Anim
        {
            get
            {
                if (anim == null)
                {
                    anim = GetComponentInChildren<Animator>();
                }
                return anim;
            }

        }

        public float speed;
        public int maxHealth;

        private int currentHealth;
        private bool attackMode;


        public Image enemyHealthBar;

        [SerializeField]
        protected Transform pointA, pointB;
        protected Vector3 currentTarget;

        // Start is called before the first frame update
        void Start()
        {
            transform.position = pointA.position;
            currentHealth = maxHealth;
            attackMode = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (Anim.GetCurrentAnimatorStateInfo(0).IsName("IdleAnim"))
            {
                return;
            }

            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }

            Movement();
            CastingRay();
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Kunai")
            {
                currentHealth -= other.GetComponent<Kunai>().damage;
                print(currentHealth);
                Life(currentHealth);
                Destroy(other.gameObject);
            }
        }

        public void CastingRay()
        {
            if (!SR.flipX)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 5f, 1 << 8);
                RaycastHit2D attackHit = Physics2D.Raycast(transform.position, Vector2.right, 0.5f, 1 << 8);

                if (attackHit)
                {
                    if (attackHit.collider.tag == "Player")
                    {
                        attackMode = true;
                        anim.SetBool("Run", false);
                        anim.SetBool("Attack", true);
                    }
                    Debug.DrawRay(transform.position, Vector2.right, Color.yellow, 3f);
                }
                else
                {
                    anim.SetBool("Attack", false);
                    attackMode = false;
                }

                if (hit)
                {
                    if (hit.collider.tag == "Player")
                    {
                        Anim.SetBool("Run", true);
                    }
                    Debug.DrawRay(transform.position, Vector2.right, Color.black, 1f);
                }
                else
                {
                    Debug.DrawRay(transform.position, Vector2.right, Color.white, 1f);
                    Anim.SetBool("Run", false);
                }
            }
            else
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 5f, 1 << 8);
                RaycastHit2D attackHit = Physics2D.Raycast(transform.position, Vector2.right, 0.5f, 1 << 8);

                if (attackHit)
                {
                    if (attackHit.collider.tag == "Player")
                    {
                        attackMode = true;
                        anim.SetBool("Run", false);
                        anim.SetBool("Attack", true);
                    }
                    Debug.DrawRay(transform.position, Vector2.right, Color.yellow, 3f);
                }
                else
                {
                    anim.SetBool("Attack", false);
                    attackMode = false;
                }

                if (hit)
                {
                    if (hit.collider.tag == "Player")
                    {
                        Anim.SetBool("Run", true);
                    }
                    Debug.DrawRay(transform.position, Vector2.left, Color.red, 1f);
                }
                else
                {
                    Debug.DrawRay(transform.position, Vector2.left, Color.blue, 1f);
                    Anim.SetBool("Run", false);
                }
            }
        }

        public void Movement()
        {
            if (transform.position == pointA.position)
            {
                currentTarget = pointB.position;
                Anim.SetTrigger("BackToIdle");
            }
            else if (transform.position == pointB.position)
            {
                currentTarget = pointA.position;
                Anim.SetTrigger("BackToIdle");
            }

            if (currentTarget == pointA.position)
            {
                SR.flipX = true;
            }
            else if (currentTarget == pointB.position)
            {

                SR.flipX = false;
            }

            if (!attackMode)
            {
                //Moving.
                transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
            }
        }

        public void Life(float damage)
        {
            enemyHealthBar.fillAmount = (damage / maxHealth);
        }
    }

}
