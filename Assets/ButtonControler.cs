using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonUI : MonoBehaviour
{
    [SerializeField] private string Level1 = "MainMenu";
    [SerializeField] private string Level2 = "MainLevel";
    public void ExitButton()
    {
        SceneManager.LoadScene(Level1);

    }
    public void PlayAgainButton()
    {
        SceneManager.LoadScene(Level2);

    }
       
}


