using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioManager Instance;


    public AudioMixer mixer;

    public string masterVolume = "Master";
    public string musicVolume = "Music";
    public string ambientVolume = "Ambient";
    public string sfxVolume = "SFX";

    // Use this for initialization
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void SetGroupVolume(string channelName, float volume)
    {
        float linearVolume = Mathf.Log(volume) * 20f;
        mixer.SetFloat(channelName, linearVolume);
    }

    public void SetMasterVolume(float volume)
    {
        SetGroupVolume(masterVolume, volume);
    }
    public void SetMusicVolume(float volume)
    {
        SetGroupVolume(musicVolume, volume);
    }
    public void SetAmbientVolume(float volume)
    {
        SetGroupVolume(ambientVolume, volume);
    }
    public void SetSFXVolume(float volume)
    {
        SetGroupVolume(sfxVolume, volume);
    }

    
}