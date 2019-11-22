using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] levelMusikChangeArray;
    //En array av AudioClip;

    private AudioSource audioSource;

    void Awake()
    {
        //Awake metod calls like Start() just once, at the begining.
        DontDestroyOnLoad(gameObject);
    }
    // Use this for initialization
    void Start()
    {

        audioSource = GetComponent<AudioSource>();
    }


    void OnLevelWasLoaded(int level)
    {
        // Debug.Log("Playing Clip: " + levelMusikChangeArray[level]);     Ett sätt
        AudioClip thisLevelMusik = levelMusikChangeArray[level];
        Debug.Log("Playing Clip: " + thisLevelMusik);

        if (thisLevelMusik)
        {
            audioSource.clip = thisLevelMusik;
            audioSource.loop = thisLevelMusik;
            audioSource.Play();
        }
    }


    public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;

    }
}
