using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelLoader : MonoBehaviour
{
    [SerializeField] int sceneNumber;
    [SerializeField] Light exitLight;

    private Transition sceneTransition;
    
    void Awake()
    {
        sceneTransition = GameObject.Find("LevelManager").GetComponent<Transition>();

        gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            sceneTransition.LoadLevel("Main_Menu");
            //SceneManager.LoadScene(sceneNumber);
        }
    }

    public void makeActive()
    {
        gameObject.SetActive(true);

        exitLight.transform.GetComponent<Light>().color = Color.green / 1.2f;
    }
}
