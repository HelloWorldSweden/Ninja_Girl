using UnityEngine;

namespace NinjaGirl
{
    public class Fire : MonoBehaviour
    {
        public GameObject projectile;
        public Transform projectilePosition;
        public Transform rotateXPos;
        public bool direction;

        private GameObject projectileParent;
        private SpriteRenderer sr;

        private void Start()
        {
            sr = GetComponent<SpriteRenderer>();
            projectileParent = GameObject.Find("ParentProjectile");
            if (!projectileParent)
            {
                projectileParent = new GameObject("ParentProjectile");
                projectileParent.name = "ParentProjectile";
            }
        }

        private void FireBall()
        {
            GameObject newProjectile = null;

            if (sr.flipX == false)
            {
                direction = false;
                newProjectile = Instantiate(projectile, projectilePosition.position, Quaternion.identity) as GameObject;
               
            }
            else
            {
                direction = true;
                newProjectile = Instantiate(projectile, rotateXPos.position, Quaternion.identity) as GameObject;
                
            }
            newProjectile.transform.parent = projectileParent.transform;
        }
    }
}

