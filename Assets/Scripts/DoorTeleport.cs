using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTeleport : MonoBehaviour
{
    public Transform endPoint;
    public GameObject player;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //Debug.Log("Player detected!");
            //player.GetComponent<Rigidbody>().transform.position = endPoint.position;

            other.GetComponentInParent<CharacterController>().enabled=false;
            other.transform.position = endPoint.position;
            other.GetComponentInParent<CharacterController>().enabled=true;
            //Debug.Log("Teleported");
        }
    }
}
