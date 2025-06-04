using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsButon : MonoBehaviour
{
    public GameObject optionsMenuUI;
    public GameObject publicUI;
    public Slider VolumeSlider;

    void Start()
    {
        if (!PlayerPrefs.HasKey("soundVolume"))
        {
            PlayerPrefs.SetFloat("soundVolume", 0.5f);
        }

        Load();
    }
 
    public void QuitGame()
    {
        Application.Quit();
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

    public void SubmitSliderSetting()
    {
        if (VolumeSlider != null)
        {
            AudioListener.volume = VolumeSlider.value;
            Debug.Log(VolumeSlider.value);
            Save();
        }
        else
        {
            Debug.LogWarning("VolumeSlider is not assigned in the Inspector!");
        }
    }

    private void Load()
    {
        if (VolumeSlider != null)
        {
            VolumeSlider.value = PlayerPrefs.GetFloat("soundVolume");
        }
        else
        {
            Debug.LogWarning("VolumeSlider is not assigned in the Inspector!");
        }
    }

    private void Save()
    {
        if (VolumeSlider != null)
        {
            PlayerPrefs.SetFloat("soundVolume", VolumeSlider.value);
        }
    }

    public void FullscreenToggle(bool toggleValue)
    {
        Screen.fullScreen = toggleValue;
    }
}
