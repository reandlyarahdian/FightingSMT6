using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSetting : MonoBehaviour
{
    public AudioMixer audiomixer;
    public AudioMixer SFXmixer;
    public Slider MusikSlider;
    public Slider SFXSlider;

    public void SetVolume(float volume)
    {
        audiomixer.SetFloat("Music",volume);
    }

    public void SetVolumeSFX(float volume)
    {
        SFXmixer.SetFloat("SFX", volume);
    }

    private void Start()
    {
        MusikSlider.value = PlayerPrefs.GetFloat("Music", 0);
        SFXSlider.value = PlayerPrefs.GetFloat("SFX", 0);
    }

    private void OnDisable()
    {
        float sistemAudio = 0;
        float SFXAudio = 0;


        audiomixer.GetFloat("Music", out sistemAudio);
        SFXmixer.GetFloat("SFX", out SFXAudio);

        PlayerPrefs.SetFloat("Music", sistemAudio);
        PlayerPrefs.SetFloat("SFX", SFXAudio);

        PlayerPrefs.Save();
    }
}
