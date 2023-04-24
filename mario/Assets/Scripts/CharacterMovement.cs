using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float jumpHeight = 2.0f;
    public float gravity = -9.81f;

    private Vector2 movementDirection;
    private float verticalVelocity = 0;

    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    public void Move(float horizontalAxis, float verticalAxis, bool jump)
    {
        movementDirection = new Vector2(horizontalAxis, verticalAxis);
        movementDirection *= movementSpeed;

        if (characterController.isGrounded)
        {
            if (jump)
            {
                verticalVelocity = Mathf.Sqrt(2f * jumpHeight * -gravity);
            }
            else
            {
                verticalVelocity = 0f;
            }
        }
        else
        {
            verticalVelocity = gravity * Time.deltaTime;
        }

        movementDirection.y = verticalVelocity;
        characterController.Move(movementDirection * Time.deltaTime);
    }
}
