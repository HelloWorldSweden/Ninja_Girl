using UnityEngine;

public class Crystal : MonoBehaviour
{
    public int antalCrystals = 1;

    [SerializeField] private ParticleSystem myParticle;


    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            Player myPlayer = other.GetComponent<Player>();

            if (myPlayer != null)
            {
                myParticle.Play();
                print("hej");
                myPlayer.AddCrystal(antalCrystals);
                Destroy(gameObject, 1f);
            }

        }

    }
}
