using System.Collections;
using UnityEngine;

namespace NinjaGirl
{
    public class Kunai : MonoBehaviour
    {
        public float speed;
        public int damage;

        private Rigidbody2D rb;
        public Rigidbody2D RB
        {
            get
            {
                if (rb == null)
                {
                    rb = GetComponent<Rigidbody2D>();
                }
                return rb;
            }
        }

        private SpriteRenderer sr;
        public SpriteRenderer SR
        {
            get
            {
                if (sr == null)
                {
                    sr = GetComponent<SpriteRenderer>();
                }
                return sr;
            }
        }

        private Fire _fire;

        private void Awake()
        {
            _fire = FindObjectOfType<Fire>();

        }
        // Start is called before the first frame update
        void Start()
        {

        }

        private void Update()
        {
            if (_fire.direction)
            {
                SR.flipX = true;
                transform.Translate(-Vector3.right * speed * Time.deltaTime);
                StartCoroutine(Delay(1f));
            }
            else
            {
                SR.flipX = false;
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                StartCoroutine(Delay(1f));
            }

        }

        private void OnTriggerEnter2D(Collider2D other)
        {
                        
            if (other.tag == "Enemy")
            {
                IDamageable hit = other.GetComponent<IDamageable>();

                if(hit != null)
                {
                    hit.Damage();
                    Destroy(this.gameObject);
                }
               
            }
            
        }

        IEnumerator Delay(float d)
        {
            yield return new WaitForSeconds(d);
            Destroy(gameObject);

        }
    }

}
