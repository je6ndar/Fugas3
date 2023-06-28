using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
        DataPersistanceManager.Instance.LoadGame();
        AdvancedSceneManager.Instance.LoadFirstLevel();
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

    public void EscButton(bool esc)
    {
        if (esc)
        {
            settings.SetActive(false);
            gameObject.SetActive(true);
        }
    }

}
