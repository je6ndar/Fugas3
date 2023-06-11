using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIExitMenu : MonoBehaviour
{
    [SerializeField] private GameObject settings;
    public void OpenCloseExitMenu(bool esc)
    {
        if (esc)
        {
            gameObject.SetActive(!gameObject.activeSelf);
            //if(Time.timeScale == 1)
            //{
            //    Time.timeScale = 0;
            //}
            //else
            //{
            //    Time.timeScale = 1;
            //}
        }
        
    }
    public void Continue()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void Settings()
    {
      settings.SetActive(true);
        gameObject.SetActive(false);
    }
    public void ExitToTheMainMenu()
    {
        AdvancedSceneManager.Instance.LoadMainMenu();
    }
}
