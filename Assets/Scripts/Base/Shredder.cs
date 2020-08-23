using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NinjaGirl
{
    public class Shredder : MonoBehaviour
    {
        private HP _hp;

        private void Start()
        {
            _hp = FindObjectOfType<HP>();
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.tag == "Player")
            {
                UIManager.Instance.restartLevel.SetActive(true);
                _hp.Health = 0;
            }
        }
    }
}

