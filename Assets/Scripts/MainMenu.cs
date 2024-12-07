using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

/*
 * A class that defines the behavior of the main menu UI
 */
public class MainMenu : MonoBehaviour
{
    [Header("Transition Object")]
    [SerializeField] Transition sceneTransition;

    //Find the level manager object
    void Awake()
    {
        sceneTransition = GameObject.Find("LevelManager").GetComponent<Transition>();
    }

    //Change scene to level_1
    public void OnPlayButton()
    {
        sceneTransition.LoadLevel("Level_1");
    }

    //Quit the game
    public void OnQuitButton()
    {
        Application.Quit();
    }

    //Change the scene to the options menu
    public void OnOptionsButtion()
    {
        sceneTransition.LoadLevel("Options");
    }

    //Go back to the main menu (in case of the win or lose screen since those canvases use this script)
    public void OnMenuButton()
    {
        sceneTransition.LoadLevel("Main_Menu");
    }
}
