using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
   public static bool GameIsPaused = false;
    OptionsButon ob;

    private void Start()
    {
        ob = GetComponent<OptionsButon>();
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
        ob.OptionsMenu();
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        ob.BackButton();
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        // menu has to be index 0
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        GameIsPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OptionsMenu()
    {
        GameIsPaused = true;
        ob.OptionsMenu();
    }

    public void BackButton()
    {
        GameIsPaused = true;
        ob.BackButton();
    }

}

