using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnEnter : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GetComponent<KillPlayer>().Kill();
        }
    }
}
