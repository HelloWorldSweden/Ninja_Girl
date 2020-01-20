using UnityEngine;


namespace NinjaGirl
{
    public class DangerZone : MonoBehaviour
    {
        public bool canFlip;

        private YK _enemy;
        private Enemy en;
        private void Start()
        {
            _enemy = FindObjectOfType<YK>();
            en = FindObjectOfType<Enemy>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                _enemy.Anim.SetBool(EnemyTransitionParameter.Attacking.ToString(), true);
                en.yAttack = true;
                
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                _enemy.Anim.SetBool(EnemyTransitionParameter.Attacking.ToString(), false);
                en.yAttack = false;
            }
        }
    }

}
