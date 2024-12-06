using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPopupText : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] AudioSource terminalLockedSound;
    [SerializeField] AudioSource terminalActivatedSound;
    private bool inCollider;
    [SerializeField] bool locked;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && inCollider && locked)
        {
            terminalLockedSound.Play();
        }
        else if(Input.GetKeyDown(KeyCode.E) && inCollider && !locked)
        {
            terminalActivatedSound.Play();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            inCollider = true;
            text.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            inCollider = false;
            text.SetActive(false);
        }
    }
}
