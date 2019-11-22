using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //Singletone
    private static UIManager _instance;

    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("UI MANAGER IS NULL");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }

    public Text playerCoins;
    public Text playerCrystals;
    public GameObject restartPanel;
    public GameObject winPanel;
    public Image[] lifeBars;

    public void ShowCoins(int antal)
    {
        playerCoins.text =  "Antal Mynt: " + "" + antal;
    }

    public void ShowCrystals(int antal)
    {
        playerCrystals.text = "Antal Crystals: " + "" + antal;
    }

    public void Restarting(bool activation)
    {
        restartPanel.SetActive(activation);
    }

    public void NextLevel(bool next)
    {
        winPanel.SetActive(next);
    }
    
    public void UpdateLives(int livesRemaining)
    {
        for(int i = 0; i <= livesRemaining; i++)
        {
            //Wait until we hit the max.
            if(i == livesRemaining)
            {
                lifeBars[i].enabled = false;
                //Hide it.
            }
        }
    }
}
