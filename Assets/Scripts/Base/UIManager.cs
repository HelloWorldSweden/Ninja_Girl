using UnityEngine;
using UnityEngine.UI;


namespace NinjaGirl
{
    public class UIManager : MonoBehaviour
    {
        //Singletone;
        private static UIManager _instance;
        public static UIManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    Debug.Log("Can't find _instance");
                }
                return _instance;
            }
        }
        private void Awake()
        {
            _instance = this;
        }

        public Text crystals;
        public Image[] lifeBars;
        public GameObject restartLevel, winPanel;


        public void ShowCrystals(int antal)
        {
            crystals.text = antal.ToString();
        }

        public void UpdateLives(int livesRemaining)
        {
            if (livesRemaining > 2)
            {
                for (int i = 0; i <= livesRemaining; i++)
                {
                    if (i == livesRemaining)
                    {
                        lifeBars[i].enabled = false;
                    }
                }
            }

            if (livesRemaining <= 2)
            {
                for (int f = 3; f >= livesRemaining; f--)
                {
                    lifeBars[f].enabled = false;
                }
            }

        }

    }
}

