using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMIS : MonoBehaviour
{
    [SerializeField] private UIMainMenu mainMenu;

    private void Update()
    {
        Debug.Log(Input.GetButtonDown("Cancel"));
        bool esc = Input.GetButtonDown("Cancel");
        mainMenu.EscButton(esc);
    }
}
