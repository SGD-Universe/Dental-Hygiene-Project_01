using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeAdjuster : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("Volume", 0.75f); // Set the volume to saved volume or to default 0.75
    }

    public void SetVolume(float sliderValue)
    {
        mixer.SetFloat("Volume", Mathf.Log10(sliderValue) * 20); // Set the volume of the Audio Mixer
        PlayerPrefs.SetFloat("Volume", sliderValue); //Save the new volume for future sessions
    }

}
