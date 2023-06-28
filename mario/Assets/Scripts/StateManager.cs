using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public static StateManager Instance { get; private set; }
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

    private bool _isPaused = false;
    private void OnEnable()
    {
        UIExitMenu.onExitMenuEnabled += Paused;
        UIExitMenu.onExitMenuDisabled += UnPaused;
    }

    private void OnDisable()
    {
        UIExitMenu.onExitMenuEnabled -= Paused;
        UIExitMenu.onExitMenuDisabled -= UnPaused;
    }

    private void Paused()
    {
        _isPaused = true;
    }

    private void UnPaused()
    {
        _isPaused = false;
    }

    private void Update()
    {
        if (_isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
