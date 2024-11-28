using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Transition sceneTransition;

    void Awake()
    {
        sceneTransition = GameObject.Find("LevelManager").GetComponent<Transition>();
    }
    //Play Level 1
    public void OnPlayButton()
    {
        sceneTransition.LoadLevel("Level_1");
        //SceneManager.LoadScene("Level_2");
    }

    //Quit the game
    public void OnQuitButton()
    {
        Application.Quit();
    }

    public void OnOptionsButtion()
    {
        sceneTransition.LoadLevel("Options");
        //SceneManager.LoadScene("Options");
    }
}
