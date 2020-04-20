using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour
{
    private Slider slider;
    public string settingsToChange;

    private void Start()
    {
        slider = GetComponent<Slider>();
        if (settingsToChange == "GameSpeed")
        {
            SetDefaultSlider("GameSpeed");
        }
        if (settingsToChange == "VolumeSFX")
        {
            SetDefaultSlider("VolumeSFX");
        }
        if (settingsToChange == "VolumeMusic")
        {
            SetDefaultSlider("VolumeMusic");
        }

    }

    private void Update()
    {
        if (settingsToChange == "GameSpeed")
        {
            ChangeValue("GameSpeed");
        }
        if (settingsToChange == "VolumeSFX")
        {
            ChangeValue("VolumeSFX");
        }
        if (settingsToChange == "VolumeMusic")
        {
            ChangeValue("VolumeMusic");
        }
    }

    private void ChangeValue(string key)
    {
        
        if (PlayerPrefs.GetFloat(key) != slider.value)
        {
            PlayerPrefs.SetFloat(key, slider.value);
        }

    }

    private void SetDefaultSlider(string key)
    {
        slider.value = PlayerPrefs.GetFloat(key);
    }
}
