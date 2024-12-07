using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A class that defines a behavior for a collider that teleports the player to another location
 */
public class DoorTeleport : MonoBehaviour
{
    [Header("Locations")]
    [SerializeField] Transform endPoint;

    [Header("Player Object")]
    [SerializeField] GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        //If the player enters the collider teleport the player
        if(other.CompareTag("Player"))
        {
            //Disable the CharacterController
            other.GetComponentInParent<CharacterController>().enabled=false;

            //Teleport the player to the end point location
            other.transform.position = endPoint.position;

            //Re-enable the CharacterController
            other.GetComponentInParent<CharacterController>().enabled=true;

            //If the collision object is the capsule of the player, reset its local position to the player
            //Had an issue where the capsule collider would not be teleported with the parent player object
            if(other.transform.name.Equals("Capsule"))
            {
                other.transform.position =  other.transform.parent.TransformPoint(0,0.3f,0);
            }
        }
    }
}
