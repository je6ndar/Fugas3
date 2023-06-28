using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //public static InputManager Instance { get; private set; }

    //private void Awake()
    //{
    //    if (Instance != null)
    //    {
    //        Destroy(gameObject);
    //        return;
    //    }

    //    Instance = this;
    //    DontDestroyOnLoad(gameObject);
    //}

    [SerializeField] private RbMovement movement;
    [SerializeField] private UIExitMenu exitMenu;
    [SerializeField] private UISettings settings;
    void Update() 
    {
        bool esc = Input.GetButtonDown("Cancel");
        exitMenu.OpenCloseExitMenu(esc);
        //settings.OpenCloseSettings(esc);
        //settings.Exit(esc);

        var horizontal = Input.GetAxisRaw("Horizontal");
        var jumpDownBtn = Input.GetButtonDown("Jump");
        var jumpUpBtn = Input.GetButtonUp("Jump");
        movement.Move(horizontal, jumpDownBtn, jumpUpBtn);
    }
}
