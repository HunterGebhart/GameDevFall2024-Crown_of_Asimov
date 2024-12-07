using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A class that defines the behavior for any colliders that may change the scene when the player enters
 */
public class ChangeScene : MonoBehaviour
{
    [SerializeField] Transition sceneTransition;
    [SerializeField] string sceneName;

    //If the player enters the collider, reset the mouse cursor and load the corresponding scene
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            sceneTransition.LoadLevel(sceneName);
        }
    }
}
