using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionController : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider diffSlider;
    public LevelManager levelManager;

    private MusicManager music;


    // Use this for initialization
    void Start()
    {

        music = GameObject.FindObjectOfType<MusicManager>();
        Debug.Log("musicManager är hittad");
        //nu ger vi volume.value to the volumeSlider.
        //get is readonly.
        volumeSlider.value = PlayerProffsManager.GetMasterVolume();
        ////read the difficulty value;
        diffSlider.value = PlayerProffsManager.GetDifficulty();
    }


    public void SaveAndExit()
    {
        PlayerProffsManager.setMasterVolume(volumeSlider.value);
        PlayerProffsManager.setDifficulty(diffSlider.value);

        levelManager.loadLevel("Level_01");
    }
    // Update is called once per frame
    void Update()
    {
        music.ChangeVolume(volumeSlider.value);
    }

    public void SetDefaults()
    {
        volumeSlider.value = 0.8f;
        diffSlider.value = 2f;
    }
}
