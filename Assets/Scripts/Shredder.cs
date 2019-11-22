using UnityEngine;

public class Shredder : MonoBehaviour
{
    private int health;
    private Player _plScript;

    [SerializeField] int damage = 5;

    private void Start()
    {
       _plScript = FindObjectOfType<Player>();
       // health = _plScript.Health;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            for (int i = 0; i < damage; i++)
            {
                _plScript.Damage();

            }
        }
    }
}
