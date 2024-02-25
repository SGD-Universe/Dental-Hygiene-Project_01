using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelManager : MonoBehaviour
{
    public AudioSource backgroundMusic;

    //triggers the playback of the background music.
    public void PlayBackgroundMusic()
    {
        backgroundMusic.Play();
    }
    

    

}
        
