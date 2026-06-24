using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider SoundSlider;
    [SerializeField] Slider MusicSlider;
    [SerializeField] AudioSource SoundSource;
    [SerializeField] AudioSource MusicSource;


  public void Start()
    {
        if(!PlayerPrefs.HasKey("SoundVolume"))
        {
            PlayerPrefs.SetFloat("SoundVolume", 1f);
            Load();
        }
        else
        {
            Load();
        }
        if (!PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetFloat("MusicVolume", 1f);
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        SoundSource.volume = SoundSlider.value;
        MusicSource.volume = MusicSlider.value;
        Save();
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("SoundVolume", SoundSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", MusicSlider.value);
    }

    public void Load()
    {
        SoundSource.volume = PlayerPrefs.GetFloat("SoundVolume");
        MusicSource.volume = PlayerPrefs.GetFloat("MusicVolume");
    }
}
