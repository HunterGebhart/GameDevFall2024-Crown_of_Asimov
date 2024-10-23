using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelLoader : MonoBehaviour
{
    public int loseSceneNumber;
    public new Light light;
    // Start is called before the first frame update
    void Awake()
    {
        gameObject.SetActive(false);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(loseSceneNumber);
        }
    }

    public void makeActive()
    {
        gameObject.SetActive(true);
        light.transform.GetComponent<Light>().color = Color.green / 1.2f;
    }
}
