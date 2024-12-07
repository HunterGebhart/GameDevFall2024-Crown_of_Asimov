using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

/* 
 * A class that defines the behavior for moving platforms
 */
public class MovingPlatform : MonoBehaviour
{
    [Header("Locations")]
    [SerializeField] Transform targetA;
    [SerializeField] Transform targetB;
    [SerializeField] Transform currTarget;

    [Header("Location Names")]
    [SerializeField] string pointA_Name;
    [SerializeField] string pointB_Name;

    [Header("Attributes")]
    [SerializeField] float speed;

    //Fine game objects and set the current target for the platform
    void Start()
    {
        targetA = GameObject.Find(pointA_Name).transform;
        targetB = GameObject.Find(pointB_Name).transform;

        currTarget = targetB;
    }

    void FixedUpdate()
    {
        //Find the distance to the target
        float distanceToA = Vector3.Distance(transform.position, targetB.position);

        //If the destination has been reached, destroy the platform
        if(distanceToA == 0f)
        {
            Destroy(gameObject);
        }

        //Move the platform toward the target location
        transform.position = Vector3.MoveTowards(transform.position, currTarget.position, speed * Time.deltaTime);
    }
}
