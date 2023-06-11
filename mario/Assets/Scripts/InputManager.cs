using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private RbMovement movement;
    [SerializeField] private UIExitMenu exitMenu;
    void Update() 
    {
        bool esc = Input.GetButtonDown("Cancel");
        exitMenu.OpenCloseExitMenu(esc);
        
        var horizontal = Input.GetAxisRaw("Horizontal");
        var jumpDownBtn = Input.GetButtonDown("Jump");
        var jumpUpBtn = Input.GetButtonUp("Jump");
        movement.Move(horizontal, jumpDownBtn, jumpUpBtn);
    }
}
