using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private CharacterMovement movement;
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
        bool jump = Input.GetButtonDown("Jump");
        movement.Move(horizontalAxis, verticalAxis, jump);
    }
}
