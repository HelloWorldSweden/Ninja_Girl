using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NinjaGirl
{
    public class Test : MonoBehaviour
    {
        private Movement _charMovement;

        private void Start()
        {
            _charMovement = GameObject.FindWithTag("Player").GetComponent<Movement>();
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player" && _charMovement.onLadder)
            {
                _charMovement.onLadder = false;
                Debug.Log("Onladder Flase");
            }
        }
    }

}
