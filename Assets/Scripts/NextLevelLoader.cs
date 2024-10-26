using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelLoader : MonoBehaviour
{
    [SerializeField] int sceneNumber;
    [SerializeField] new Light light;
    
    void Awake()
    {
        gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            SceneManager.LoadScene(sceneNumber);
        }
    }

    public void makeActive()
    {
        gameObject.SetActive(true);

        light.transform.GetComponent<Light>().color = Color.green / 1.2f;
    }
}
