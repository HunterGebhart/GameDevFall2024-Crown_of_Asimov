using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Play Level 1
    public void OnPlayButton()
    {
        SceneManager.LoadScene(1);
    }

    //Quit the game
    public void OnQuitButton()
    {
        Application.Quit();
    }
}
