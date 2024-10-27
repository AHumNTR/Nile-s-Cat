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
    
    public AudioClip[] audioClips;
    private AudioSource[] _audioSource;

    private void Start()
    {
        _audioSource = GetComponents<AudioSource>();
    }

    public void PlayButtonSound(int index)
    {
        _audioSource[1].clip = audioClips[index];
        _audioSource[1].Play();
    }

    public void PlaySoundEffect(int index)
    {
        _audioSource[1].clip = audioClips[index];
        _audioSource[1].Play();
    }

    public void PlayMusic(int index)
    {
        _audioSource[0].clip = audioClips[index];
        _audioSource[0].Play();
    }

    public void StopMusic()
    {
        _audioSource[0].Stop();
    }
}
