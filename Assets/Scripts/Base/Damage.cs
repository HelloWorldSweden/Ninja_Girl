using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NinjaGirl
{
    public class Damage : MonoBehaviour
    {
        
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

