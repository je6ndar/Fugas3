using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIExitMenu : MonoBehaviour
{

    [SerializeField] private GameObject settings;
    public static Action onExitMenuEnabled;
    public static Action onExitMenuDisabled;
    public void OpenCloseExitMenu(bool esc)
    {
        if (esc)
        {
            Debug.Log(gameObject.activeSelf + " " + settings.activeSelf);

            if (gameObject.activeSelf == false && settings.activeSelf == false)
            {
                gameObject.SetActive(!gameObject.activeSelf);
                onExitMenuEnabled?.Invoke();
            }

            if (gameObject.activeSelf)
            {
                gameObject.SetActive(!gameObject.activeSelf);
                onExitMenuDisabled?.Invoke();
            }

            if (settings.activeSelf == false && gameObject.activeSelf == true)
            {
                settings.SetActive(!settings.activeSelf);
                gameObject.SetActive(!gameObject.activeSelf);
            }
        }
    }
    public void Continue()
    {
        gameObject.SetActive(!gameObject.activeSelf);
        onExitMenuDisabled?.Invoke();
    }

    public void Settings()
    {
        settings.SetActive(true);
        gameObject.SetActive(false);
    }
    public void ExitToTheMainMenu()
    {
        //DataPersistanceManager.Instance.SaveGame();
        AdvancedSceneManager.Instance.LoadMainMenu();
        onExitMenuDisabled?.Invoke();
    }

}
