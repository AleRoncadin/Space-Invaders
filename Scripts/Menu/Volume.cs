using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Volume : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    public void Start()
    {
        if (!PlayerPrefs.HasKey("soundVolume"))
        {
            PlayerPrefs.SetFloat("soundVolume", 1f);
            Load();
        }

        else
            Load();
    }
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    public void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("soundVolume");
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("soundVolume", volumeSlider.value);
    }
}
