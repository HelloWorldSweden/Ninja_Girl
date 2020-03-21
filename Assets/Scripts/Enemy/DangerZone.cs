using UnityEngine;


namespace NinjaGirl
{
    public class DangerZone : MonoBehaviour
    {
        public bool canFlip;

        private Zombie _enemy;
       
        private void Start()
        {
            _enemy = FindObjectOfType<Zombie>();
          
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                IDamageable hit = other.GetComponent<IDamageable>();
                if(hit != null)
                {
                    hit.Damage();
                }
                _enemy.Anim.SetBool(EnemyAnimationTransition.Attacking.ToString(), true);
               
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                _enemy.Anim.SetBool(EnemyAnimationTransition.Attacking.ToString(), false);
               
            }
        }
    }

}
