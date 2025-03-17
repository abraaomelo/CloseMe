using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    [Header("---------- Audio Source----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("----------Audio Clip----------")]
    public AudioClip menuBackground;
    public AudioClip shootingGame;
    public AudioClip mouseClick;
    public AudioClip gameOver;
    public AudioClip notificationAlert;
    public AudioClip shotSound;
    public AudioClip winnerSound;

    void Start()
    {
        musicSource.clip = menuBackground;
        musicSource.Play();

    }

    public void StopMusic(){
        musicSource.Stop();
    }

    public void PlayMusic(AudioClip clip){
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
