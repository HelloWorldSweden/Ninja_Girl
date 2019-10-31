using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COIN_T : MonoBehaviour
{
    public int antalCoins = 1;
    //public ParticleSystem myParticle;
    public GameObject myParticle;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player myPlayer = other.GetComponent<Player>();

            GameObject mp = Instantiate(myParticle, transform.position, Quaternion.identity) as GameObject;
            print("Instantiate");

            if (myPlayer != null)
            {
                myPlayer.AddCoins(antalCoins);
                                
                Destroy(this.gameObject, 1.5f);
            }

            Destroy(mp, 1.5f);
        }
    }
}
