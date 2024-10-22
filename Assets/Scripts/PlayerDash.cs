using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Default values:
 * dashspeed = 2f;
 * dashTime = 0.1f;
 * cooldownTime = 1f;
 * rayDistance = 2f;
 */

public class DashMechanic : MonoBehaviour
{
    public Camera playerCam;

    public LayerMask wallMask;

    private RaycastHit hit;

    public float dashSpeed = 1f;
    public float dashTime = 0.25f;
    public float cooldownTime = 1.0f;
    public float rayDistance = 1.75f;

    private float startingFOV; 

    bool canDash = true;

    void Start() 
    {
        startingFOV = playerCam.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        //Handles dashing
        if(canDash)
        {
            //if dash left
            if(Input.GetKey(KeyCode.A))
            {
                if(Input.GetKeyDown(KeyCode.LeftShift))
                {
                    //0 is the code for left
                    StartCoroutine(Dash(0));
                }
            }
            //if dash right
            if(Input.GetKey(KeyCode.D))
            {
                if(Input.GetKeyDown(KeyCode.LeftShift))
                {
                    //2 is the code for right
                    StartCoroutine(Dash(2));
                }
            }
            //if dash back
            if(Input.GetKey(KeyCode.S))
            {
                if(Input.GetKeyDown(KeyCode.LeftShift))
                {
                    //3 is the code for back
                    StartCoroutine(Dash(3));
                }
            }
            //if dash forward
            if(Input.GetKey(KeyCode.W))
            {
                if(Input.GetKeyDown(KeyCode.LeftShift))
                {
                    //1 is the code for forward
                    StartCoroutine(Dash(1));
                }
            }
        }
    }

    //Dash Coroutine
    IEnumerator Dash(int directionCode)
    {
        canDash = false;

        //Dash left
        if(directionCode == 0)
        {
            float startTime = Time.time;

            while(Time.time < startTime + dashTime)
            {
                RaycastHit hit;

                // Does the ray intersect any objects excluding the player layer
                if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right * -1), out hit, rayDistance, wallMask))
                {
                    //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                    //Debug.Log("No Collision!");
                    transform.Translate(Vector3.right * dashSpeed * -1);
                }
                else 
                {
                    startTime -= 100f;
                    //Debug.Log("Collision!");
                }

                yield return null;
            }
            
        }
        //Dash right
        if(directionCode == 2)
        {
            float startTime = Time.time;

            while(Time.time < startTime + dashTime)
            {
                RaycastHit hit;

                // Does the ray intersect any objects excluding the player layer
                if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, rayDistance, wallMask))
                {
                    //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                    //Debug.Log("No Collision!");
                    transform.Translate(Vector3.right * dashSpeed);
                }
                else 
                {
                    startTime -= 100f;
                    //Debug.Log("Collision!");
                }
                
                yield return null;
            }
        }
       
        //Dash forward
        if(directionCode == 1)
        {
            float startTime = Time.time;

            while(Time.time < startTime + dashTime)
            {
                RaycastHit hit;

                // Does the ray intersect any objects excluding the player layer
                if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayDistance, wallMask))
                {
                    //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                    //Debug.Log("No Collision!");
                    transform.Translate(Vector3.forward * dashSpeed);
                }
                else
                {
                    startTime -= 100f;
                    //Debug.Log("Collision!");
                } 

                yield return null;
            }
        }
        
        //Dash backward
        if(directionCode == 3)
        {
            float startTime = Time.time;

            while(Time.time < startTime + dashTime)
            {
                RaycastHit hit;

                // Does the ray intersect any objects excluding the player layer
                if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward * -1), out hit, rayDistance, wallMask))
                {
                    //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                    //Debug.Log("No Collision!");
                    transform.Translate(Vector3.forward * dashSpeed * -1);
                }
                else 
                { 
                    startTime -= 100f;
                    //Debug.Log("Collision!");
                }

                yield return null;
            }
        }

        //dash cooldown
        yield return new WaitForSeconds(cooldownTime);

        canDash = true;
    }
}

