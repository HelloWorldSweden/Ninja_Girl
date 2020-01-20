using UnityEngine;

namespace NinjaGirl
{
    public class YK : Enemy, IDamageable
    {
        public int Health { get; set; }

        private Animator _anim;
        public Animator Anim
        {
            get
            {
                if(_anim == null)
                {
                    _anim = GetComponentInChildren<Animator>();

                }
                return _anim;
            }
            
        }


        public override void Init()
        {
            base.Init();
            Health = enemyHealth;
            transform.position = pointA.position;
        }

        public override void Movement()
        {
            base.Movement();
            if(Health <= 0)
            {
                Destroy(gameObject);
            }
        }


        public void Damage()
        {
            Health--;
            
        }
    }

}
