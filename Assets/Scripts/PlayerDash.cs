using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMechanic : MonoBehaviour
{
    [Header("Object References")]
    [SerializeField] Camera playerCam;
    [SerializeField] LayerMask wallMask;

    private RaycastHit hit;

    [Header("Dash Attributes")]
    [SerializeField] float dashSpeed = 1f;
    [SerializeField] float dashTime = 0.25f;
    [SerializeField] float cooldownTime = 1.0f;
    [SerializeField] float rayDistance = 1.75f;

    private bool canDash = true;

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

                if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right * -1), out hit, rayDistance, wallMask))
                {
                    transform.Translate(Vector3.right * dashSpeed * -1);
                }
                else 
                {
                    startTime -= 100f;
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

                if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, rayDistance, wallMask))
                {
                    transform.Translate(Vector3.right * dashSpeed);
                }
                else 
                {
                    startTime -= 100f;
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

                if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayDistance, wallMask))
                {
                    transform.Translate(Vector3.forward * dashSpeed);
                }
                else
                {
                    startTime -= 100f;
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

                if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward * -1), out hit, rayDistance, wallMask))
                {
                    transform.Translate(Vector3.forward * dashSpeed * -1);
                }
                else 
                { 
                    startTime -= 100f;
                }

                yield return null;
            }
        }

        yield return new WaitForSeconds(cooldownTime);

        canDash = true;
    }
}

