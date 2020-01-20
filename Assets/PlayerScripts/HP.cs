using UnityEngine;


namespace NinjaGirl
{
    public class HP : MonoBehaviour, IDamageable
    {
        private int crystalsNumber = 0;
        private Movement _charMovement;
        public int Health { get; set; }
        private Vector3 currentPosition;
        // Start is called before the first frame update
        void Start()
        {
            Health = 4;
            _charMovement = GetComponent<Movement>();
            currentPosition = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (Health <= 0)
            {
                _charMovement.isAlive = false;
                Destroy(gameObject);
                transform.position = currentPosition;
                UIManager.Instance.restartLevel.SetActive(true);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "crystal")
            {
                crystalsNumber++;
                UIManager.Instance.ShowCrystals(crystalsNumber);
                Destroy(other.gameObject);
            }

            if(other.tag == "Final")
            {
                UIManager.Instance.restartLevel.SetActive(true);
            }
            else
            {
                UIManager.Instance.restartLevel.SetActive(false);
            }
        }

        public void Damage()
        {
            if(_charMovement.isAlive)
            {
                Health--;
                UIManager.Instance.UpdateLives(Health);
            }
         
        }


    }

}
