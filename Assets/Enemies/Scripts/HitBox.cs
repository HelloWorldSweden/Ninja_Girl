using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NinjaGirl
{
    public class HitBox : MonoBehaviour
    {
        private SpriteRenderer sr;
        public GameObject hitBox, hitBox1;
        // Start is called before the first frame update
        void Start()
        {
            sr = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            if (sr.flipX)
            {
                hitBox1.SetActive(true);
                hitBox.SetActive(false);
            }
            else
            {
                hitBox.SetActive(true);
                hitBox1.SetActive(false);
            }

        }
    }

}
