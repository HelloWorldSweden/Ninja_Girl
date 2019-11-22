using UnityEngine;

public class Thorns : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            print("Get Component");
            other.GetComponent<Player>().Damage();
        }
    }


}
