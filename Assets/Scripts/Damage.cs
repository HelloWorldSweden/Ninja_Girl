﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NinjaGirl
{
    public class Damage : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                IDamageable hit = other.GetComponent<IDamageable>();
                Debug.Log("Hitting the player");
                if (hit != null)
                {
                    hit.Damage();
                }
            }
        }

    }
}
