using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdvancedSceneManager : MonoBehaviour
{
    public static AdvancedSceneManager Instance { get; private set; }

    private const string MAIN_MENU_SCENE_KEY = "MainMenu";
    private const string EXIT_MENU_SCENE_KEY = "ExitMenu";
    private const string SETTINGS_SCENE_KEY = "Settings";
    private string[] LEVELS_SCENE_KEYS = new string[] { "FirstLevel", "SecondLevel", "ThirdLevel" };

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(MAIN_MENU_SCENE_KEY);
    }

    public void LoadExitMenu()
    {
        SceneManager.LoadScene(EXIT_MENU_SCENE_KEY);
    }
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(LEVELS_SCENE_KEYS[0]);
    }
    public void LoadSettings()
    {
        SceneManager.LoadScene(SETTINGS_SCENE_KEY);
    }

    public void LoadNextLevel()
    {
        var currentLevel = SceneManager.GetActiveScene().name;
        var currentSceneIndex = Array.IndexOf(LEVELS_SCENE_KEYS, currentLevel);
        if(currentSceneIndex + 1>= LEVELS_SCENE_KEYS.Length)
        {
            Debug.LogError("Index of levels scenes is out of rage");
        }
        SceneManager.LoadScene(LEVELS_SCENE_KEYS[currentSceneIndex + 1]);
    }
}
