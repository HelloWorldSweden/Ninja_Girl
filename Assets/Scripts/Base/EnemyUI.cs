using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    //En singleton.
    private static EnemyUI _instance;

    public static EnemyUI Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.Log("UI is Null");
            }
            return _instance;

        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public Image enemyHealthBar;
    
    public void Life(float damage)
    {
        enemyHealthBar.fillAmount -= (damage * 0.1f);
    }
  
}
