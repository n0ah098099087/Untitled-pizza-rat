using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
   public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject OptionsMenuUI;

    public AudioMixer audioMixer;

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

    // Update is called once per frame
    void Update()
    {
     if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused )
            {
                Resume();
            }
            else 
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
       pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        // menu has to be index 0
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OptionsMenu()
    {
        pauseMenuUI.SetActive(false);
        GameIsPaused = true;
        OptionsMenuUI.SetActive(true);
    }

    public void BackButton()
    {
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
        OptionsMenuUI.SetActive(false);

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

