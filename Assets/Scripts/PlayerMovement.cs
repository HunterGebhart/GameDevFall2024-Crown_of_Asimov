using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController playerController;

    Vector3 velocity;

    public float moveSpeed = 12f;
    public float runSpeed = 12f;
    public float walkSpeed = 6f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    bool isWalking;

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
    }
}
