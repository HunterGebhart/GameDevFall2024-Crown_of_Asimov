using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * A class that defines the behavior of the enemy projectiles
 */
public class BulletBehavior : MonoBehaviour
{
    [Header("Bullet Settings")]
    [SerializeField] float bulletDespawnTime;
    [SerializeField] string scene;
    
    //Destroy the bullet after a set amount of time if it does not collide with anything
    private void Start()
    {
        Destroy(gameObject, bulletDespawnTime);
    }

    //The behavior once the bullet collides with something
    private void OnTriggerEnter(Collider other)
    {
        //If the bullet collides with a player, reset the mouse cursor to normal, destroy the bullet, and load the scene
        if(other.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Destroy(gameObject);

            SceneManager.LoadScene(scene);
        }
        //If the bullet collides with anything else, destroy the bullet
        else
        {
            Destroy(gameObject);         
        }
    }
}
