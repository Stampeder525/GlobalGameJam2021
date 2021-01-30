using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //Instance
    public static SoundManager instance;

    [Header("Music")]
    public AudioSource musicSource;
    public List<AudioClip> musicSoundtrack;

    [Header("SFX")]
    public AudioSource effectSource;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void StartMusic()
    {
        musicSource.Play();
    }

    public void StopMusic()
    {
        Debug.Log(musicSource.clip);
        musicSource.Stop();
    }

    public void PlayMusic(AudioClip theme)
    {
        musicSource.clip = theme;
        musicSource.Play();
    }

    public void PlayMusicOneShot(AudioClip theme)
    {
        musicSource.PlayOneShot(theme);
    }

    public void PlayEffect(AudioClip clip)
    {
        effectSource.clip = clip;
        effectSource.Play();
    }

    public void PlayEffectOneShot(AudioClip clip)
    {
        effectSource.PlayOneShot(clip);
    }
}