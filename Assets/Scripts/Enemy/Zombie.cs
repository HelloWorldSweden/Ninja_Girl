namespace NinjaGirl
{
    public class Zombie : EnemyMovement, IDamageable
    {
        public int Health { get; set; }

        public void Damage()
        {
            Health--;
        }

        // Start is called before the first frame update
        private void Start()
        {
            Health = enemyHealth;
            transform.position = pointA.position;
        }

        public override void Movement()
        {
            base.Movement();
            if (Health <= 0)
            {
                Destroy(gameObject);
            }
        }




    }
}

