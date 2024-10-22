using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletBehavior : MonoBehaviour
{
    public float bulletDespawnTime;
    public int loseSceneNumber;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, bulletDespawnTime);
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
            Destroy(gameObject);
            SceneManager.LoadScene(loseSceneNumber);
        }
        else
        {
            Destroy(gameObject);         
        }
    }
}
