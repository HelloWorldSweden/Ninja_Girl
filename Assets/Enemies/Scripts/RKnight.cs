using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NinjaGirl
{
    public class RKnight : Enemy, IDamageable
    {
        public int Health { get; set; }

        public override void Init()
        {
            base.Init();
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


        public void Damage()
        {
            Health--;

        }
    }

}
