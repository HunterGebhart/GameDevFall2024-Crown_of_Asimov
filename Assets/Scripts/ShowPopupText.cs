using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A class that displays text if the player is in the collider
 */
public class ShowPopupText : MonoBehaviour
{
    [Header("Text to display")]
    [SerializeField] private GameObject text;

    [Header("Audio Sources")]
    [SerializeField] AudioSource terminalLockedSound;
    [SerializeField] AudioSource terminalActivatedSound;

    [Header("Booleans")]
    [SerializeField] bool locked;

    private bool inCollider;

    void Update()
    {
        //If the terminal is supposed to be locked and the player presses E in the collider, play the locked SFX
        if(Input.GetKeyDown(KeyCode.E) && inCollider && locked)
        {
            terminalLockedSound.Play();
        }
        //If the terminal isn't supposed to be locked and the player presses E in the collider, play the activated SFX
        else if(Input.GetKeyDown(KeyCode.E) && inCollider && !locked)
        {
            terminalActivatedSound.Play();
        }
    }

    //If the player is in the collider, display the text
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            inCollider = true;
            text.SetActive(true);
        }
    }

    //If the player leaves the collider, hide the text
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            inCollider = false;
            text.SetActive(false);
        }
    }
}
