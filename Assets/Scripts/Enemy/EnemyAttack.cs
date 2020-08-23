using UnityEngine;

namespace NinjaGirl
{
    public class EnemyAttack : MonoBehaviour
    {
        public int damage;

        private HP playerHealth;

        private void Awake()
        {
            playerHealth = FindObjectOfType<HP>();
        }
        //Har ändrat namnet.
        public void ZombieAttack()
        {
            playerHealth.Health -= damage;
            UIManager.Instance.UpdateLives(playerHealth.Health);
        }

    }

}
