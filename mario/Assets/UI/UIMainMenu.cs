using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private GameObject settings;
    public void NewGame()
    {
        AdvancedSceneManager.Instance.LoadFirstLevel();
    }

    public void Continue()
    {
        //
    }

    public void Settings()
    {
        settings.SetActive(true);
        gameObject.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
