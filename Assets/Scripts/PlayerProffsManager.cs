using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProffsManager : MonoBehaviour
{
    const string Master_Volume_Key = "master-volume";
    const string Difficulty_Key = "difficulty";
    const string Level_Key = "level-unlocked_";
    //level-unlocked_0,1,2etc...



    public static void setMasterVolume(float volume)
    {
        if (volume > 0f && volume <= 1f)
        {
            PlayerPrefs.SetFloat(Master_Volume_Key, volume);
        }
        else
        {
            Debug.LogError("Changning Volume It's not possible");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(Master_Volume_Key);
    }

    public static void setDifficulty(float diff)
    {
        if (diff > 1f && diff <= 3f)
        {
            PlayerPrefs.SetFloat(Difficulty_Key, diff);
        }
        else
        {
            Debug.Log("Difficulty is Out of Range");
        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(Difficulty_Key);
    }


    public static void unlockLevel(int level)
    {
        if (level <= Application.levelCount - 1)
        {
            //array is zerobased and then we writed -1;
            PlayerPrefs.SetInt(Level_Key + level.ToString(), 1);
        }
        else
        {
            Debug.Log("Trying to Unlonck some Level");
        }
    }

    public static bool isLevelUnlocked(int level)
    {
        int levelValue = PlayerPrefs.GetInt(Level_Key + level.ToString());
        bool isLevelUnlocked = (levelValue == 1);


        if (level <= Application.levelCount - 1)
        {
            return isLevelUnlocked;
        }
        else
        {
            Debug.Log("Trying to load level which is not in the Build Order");
            return false;
        }
    }
}
