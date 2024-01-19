using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    public void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            loadVolumeMusic();
        } else setVolumeMusic();
        if (PlayerPrefs.HasKey("sfxVolume"))
        {
            loadVolumeSFX();
        } else setVolumeSFX();
    }
    public void setVolumeMusic()
    {
        float volume = musicSlider.value;
        PlayerPrefs.SetFloat("musicVolume", volume);
        myMixer.SetFloat("music", volume);
    }
    public void setVolumeSFX()
    {
        float volume = sfxSlider.value;
        PlayerPrefs.SetFloat("sfxVolume", volume);
        myMixer.SetFloat("sfx", volume);
    }
    public void loadVolumeMusic()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        setVolumeMusic();
    }
    public void loadVolumeSFX()
    {
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        setVolumeSFX();
    }
}
