using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    private CharacterController characterController;

    public float speed = 10f;
    public float jumpForce = 5f; // Increase the jump force for a higher jump.
    public float jumpDuration = 0.5f; // Adjust the jump duration as needed.
    private Vector3 movement;
    private float verticalVelocity = 0f;
    private bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate movement direction based on the current character rotation.
        movement = transform.TransformDirection(Vector3.forward) * verticalInput * speed;

        // Rotate the character to face left when the left arrow key is pressed.
        if (horizontalInput < 0)
        {
            transform.Rotate(Vector3.up, -90f * Time.deltaTime);
        }
        // Rotate the character to face right when the right arrow key is pressed.
        else if (horizontalInput > 0)
        {
            transform.Rotate(Vector3.up, 90f * Time.deltaTime);
        }

        if (characterController.isGrounded)
        {
            // Handle jumping when the character is grounded and the Jump button is pressed.
            if (Input.GetButtonDown("Jump"))
            {
                isJumping = true;
                verticalVelocity = jumpForce;
            }
        }

        // make sure doesnt float in the air.
        verticalVelocity += Physics.gravity.y * Time.deltaTime;

        // Check if the capsule is in the air due to jumping.
        if (isJumping)
        {
            movement.y = verticalVelocity;
        }
        else
        {
            // capsule is not jumping, so apply gravity.
            movement.y = verticalVelocity;
        }

        // Move the character using the CharacterController.
        characterController.Move(movement * Time.deltaTime);

        // Check if the character has landed after a jump.
        if (characterController.isGrounded)
        {
            isJumping = false;
            // Ensure that the character rests on the ground without any vertical velocity.
            movement.y = 0f;
        }
    }
}


