using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsButon : MonoBehaviour
{
    public GameObject optionsMenuUI;
    public GameObject publicUI;

    void Start()
    {
        if (!PlayerPrefs.HasKey("soundVolume"))
        {
            PlayerPrefs.SetFloat("soundVolume", 0.5f);
            Load();
        }

        else
        {
            Load();
        }

    }
    public void OptionsMenu()
    {
        publicUI.SetActive(false);
       
        optionsMenuUI.SetActive(true);
    }

    public void BackButton()
    {
        publicUI.SetActive(true);
 
        optionsMenuUI.SetActive(false);

    }

    // about here is where i got humbled 

    public Slider VolumeSlider;
    public void SubmitSliderSetting()
    {
        //Displays the value of the slider in the console.
        AudioListener.volume = VolumeSlider.value;
        Debug.Log(VolumeSlider.value);
        Save();
    }

    private void Load()
    {
        VolumeSlider.value = PlayerPrefs.GetFloat("soundVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("soundVolume", VolumeSlider.value);
    }

    public void FullscreenToggle(bool toggleValue)
    {
        // Toggle fullscreen
        Screen.fullScreen = toggleValue;
    }

}
