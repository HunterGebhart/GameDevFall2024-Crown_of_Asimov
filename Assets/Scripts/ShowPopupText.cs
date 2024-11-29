using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPopupText : MonoBehaviour
{
    [SerializeField] private GameObject text;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            text.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            text.SetActive(false);
        }
    }
}
