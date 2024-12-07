using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

/* 
 * A class that defines basic movement options for the player such a running, walking, and jumping
 */
public class PlayerMovement : MonoBehaviour
{
    [Header("Character Controller")]
    [SerializeField] CharacterController playerController;

    [Header("Movement Attributes")]
    [SerializeField] float moveSpeed = 12f;
    [SerializeField] float runSpeed = 12f;
    [SerializeField] float walkSpeed = 6f;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float jumpHeight = 3f;

    [Header("Audio Sources")]
    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource jumpLandingSound;

    private Vector3 velocity;

    private bool isWalking;
    private bool midJump = true;

    //Update is called every frame, and since movement does utilize the physics engine it does not use FixedUpdate()
    void Update()
    {
        //If player is mid air, play a landing sound effect when the player lands
        if(playerController.isGrounded && midJump)
        {
            jumpLandingSound.Play();
            midJump = false;
        }
        if(!playerController.isGrounded) midJump = true;

        //If player holds down the C key, they will walk instead of run, run is default player speed
        isWalking = Input.GetKey(KeyCode.C);

        moveSpeed = isWalking ? walkSpeed : runSpeed;

        // If the player is not in the air and velocity is less than 0, reset player velocity so that velocity 
        // doesn't increase constantly while grounded
        if(playerController.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Get input directions from player input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Set a Vector3 move to the correct directions
        Vector3 move = (transform.right * x) + (transform.forward * z);

        //If player presses the Jump button (Space in most cases) then set velocity to simulate a jump 
        if(Input.GetButton("Jump") && playerController.isGrounded)
        {
            jumpSound.Play();
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //Move player according to keyboard input
        playerController.Move(move * moveSpeed * Time.deltaTime);

        //Set velocity due to gravity
        velocity.y += gravity * Time.deltaTime;

        //Pull player downwards to simulate gravity
        playerController.Move(velocity * Time.deltaTime);
    }
}
