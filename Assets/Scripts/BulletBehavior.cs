using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletBehavior : MonoBehaviour
{
    [Header("Bullet Settings")]
    [SerializeField] float bulletDespawnTime;
    [SerializeField] int sceneNumber;
    
    void Start()
    {
        Destroy(gameObject, bulletDespawnTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Destroy(gameObject);

            SceneManager.LoadScene(sceneNumber);
        }
        else
        {
            Destroy(gameObject);         
        }
    }
}
