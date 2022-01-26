using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixerMusic;
    public AudioMixer mixerEffects;

    public void SetMusicLevel (float sliderValue)
    {
        mixerMusic.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
    }

    public void SetEffectLevel (float sliderValue)
    {
        mixerEffects.SetFloat("EffectVolume", Mathf.Log10(sliderValue) * 20);
    }

    public void Start()
    {
        mixerEffects.SetFloat("MusicVolume", Mathf.Log10(0.2f) * 20);
        mixerEffects.SetFloat("EffectVolume", Mathf.Log10(0.85f) * 20);
    }
}
