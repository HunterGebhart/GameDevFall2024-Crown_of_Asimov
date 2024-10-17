using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController playerController;

    Vector3 velocity;

    public LayerMask wallMask;

    public float moveSpeed = 12f;
    public float runSpeed = 12f;
    public float walkSpeed = 6f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float dashSpeed = 1f;
    public float dashTime = 0.25f;
    public float cooldownTime = 1.0f;
    public float rayDistance = 1.75f;

    bool isWalking;
    bool canDash = true;
    // Update is called once per frame
    void Update()
    {
        isWalking = Input.GetKey(KeyCode.C);

        moveSpeed = isWalking ? walkSpeed : runSpeed;

        if(playerController.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = (transform.right * x) + (transform.forward * z);

        if(Input.GetButton("Jump") && playerController.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        playerController.Move(move * moveSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        playerController.Move(velocity * Time.deltaTime);

        dashCall();
    }

    void dashCall()
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
                //else Debug.Log("Collision!");

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
                //else Debug.Log("Collision!");
                
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
                //else Debug.Log("Collision!");

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
                //else Debug.Log("Collision!");

                yield return null;
            }
        }

        //dash cooldown for 2.5 seconds
        yield return new WaitForSeconds(cooldownTime);

        canDash = true;
    }
}
