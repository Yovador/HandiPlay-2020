using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioEmitter : MonoBehaviour
{
    public string sourceName;
    public bool isMusic;
    public bool hasToLoop;
    private bool playOnceOn = false;
    public AudioClip clipToPlay;
    private AudioSource source;

    private void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isMusic)
        {
            source.volume = PlayerPrefs.GetFloat("VolumeMusic");
            Debug.Log("Source Music Volume : " + source.volume);
        }
        else
        {
            source.volume = PlayerPrefs.GetFloat("VolumeSFX");
            Debug.Log("Source SFX Volume : " + source.volume);

        }

        source.loop = hasToLoop;

        if (AudioManager.soundToPlay.Contains(sourceName))
        {
            if (!playOnceOn)
            {
                StartCoroutine(PlaySoundOnce());
            }

            if (!source.isPlaying)
            {
                AudioManager.soundToPlay.Remove(sourceName);
            }
        }
        else
        {
            source.Stop();
        }
    }
    private IEnumerator PlaySoundOnce()
    {
        playOnceOn = true;
        PlaySound(clipToPlay);
        yield return new WaitForSecondsRealtime(clipToPlay.length);
        AudioManager.soundToPlay.Remove(sourceName);
        playOnceOn = false;
    }
    private void PlaySound(AudioClip clip)
    {
        if (!source.isPlaying)
        {
            source.clip = clip;
            source.Play();
        }

    }
}
