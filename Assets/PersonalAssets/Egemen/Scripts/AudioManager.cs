using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Singleton

    public static AudioManager Instance;
        
    private void Awake()
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

    #endregion
    
    public Sound[] Sounds;
    private AudioSource _audioSource;

    public void PlayButtonSound(string soundName)
    {
        var sound = Array.Find(Sounds, sound1 => sound1.name == soundName);

        _audioSource.clip = sound.audioClip;
        _audioSource.Play();
    }
}
