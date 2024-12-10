using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer; // Reference to the AudioMixer for volume control
    public Slider volumeSlider;   // Reference to the volume slider
    public Slider brightnessSlider; // Reference to the brightness slider
  

    private Resolution[] resolutions;

    void Start()
    {
        

        // Initialize volume and brightness sliders
        float volume;
        audioMixer.GetFloat("MasterVolume", out volume);
        volumeSlider.value = Mathf.Pow(10, volume / 20); // Convert decibel to linear scale

        brightnessSlider.value = RenderSettings.ambientIntensity; // Default brightness value
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20); // Convert linear scale to decibel
    }

    public void SetBrightness(float brightness)
    {
        RenderSettings.ambientIntensity = brightness; // Adjust ambient light intensity
    }

  
}
