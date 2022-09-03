using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;

    public void SetVolume(float sliderValue)
    {
        mixer.SetFloat("masterVolume", Mathf.Log10(sliderValue) * 20);    
    }
}
