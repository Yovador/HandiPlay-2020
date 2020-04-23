using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static float volumeSFX = 0.5f;
    public static float volumeMusic = 0.5f;
    public static List<string> soundToPlay = new List<string>();

    private void Start()
    {
        if (!PlayerPrefs.HasKey("VolumeSFX"))
        {
            PlayerPrefs.SetFloat("VolumeSFX", volumeSFX);
        }

        if (!PlayerPrefs.HasKey("VolumeMusic"))
        {
            PlayerPrefs.SetFloat("VolumeMusic", volumeMusic);
        }
    }

    public static void PlayASound(string sound)
    {
        if (!soundToPlay.Contains(sound))
        {
            //Debug.Log("Added : " + sound);
            soundToPlay.Add(sound);
        }
    }

    private void Update()
    {
        if (GameManager.gameState == 0)
        {
            PlayASound("MainMenuMusic");
        }
        if (GameManager.gameState == 1)
        {
            PlayASound("InGameMusic");
        }
        if (GameManager.gameState == 2)
        {
            PlayASound("CreditMusic");
        }

        //Debug Only :
        /*foreach (var item in soundToPlay)
        {
            Debug.Log("Sound to play : " + item);
        }*/
    }
}
