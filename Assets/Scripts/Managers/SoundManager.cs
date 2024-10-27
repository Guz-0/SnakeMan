using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance { get; private set; }

    public AudioSource musicSource;
    public AudioSource effectsSource;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PlaySpecificClip(AudioClip audioToPlay)
    {
        effectsSource.PlayOneShot(audioToPlay);
    }

    public void PlayMusic()
    {
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void SetMusicVolume(float volumeValue)
    {
        musicSource.volume = volumeValue; 
    }

    public float GetMusicVolume()
    {
        return musicSource.volume;
    }

    public void PauseMusic(bool value)
    {
        if (value == true)
        {
            musicSource.Pause();
        }
        else
        {
            musicSource.UnPause();
        }
    }

    public void SetEffectsVolume(float volumeValue)
    {
        effectsSource.volume = volumeValue;
    }

    public float GetEffectsVolume()
    {
        return effectsSource.volume;
    }
}
