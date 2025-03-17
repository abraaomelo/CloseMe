using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    private AudioSource[] mySounds;
    private AudioSource bgSong;
    private AudioSource gameplaySong;
    
    private void Start()
    {
        mySounds = GetComponents<AudioSource>();

        //bgSong = mySounds[1];
        //gameplaySong = mySounds[1];
    }

    public void PlayBgSong(){
       // bgSong.Play();
    }

    // public void PlaygamePlaySong(){
    //     gameplaySong.Play();
    // }
    // public void StopgamePlaySong(){
    //     gameplaySong.Stop();
    // }


}
