using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour, IDataPersistance
{
    //public static PlayerStats Instance { get; private set; }

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

    private static int playerHealth = 3;
    private static int playerDamage = 1;
    private static int coinsCollected = 0;

    private void OnEnable()
    {
        PlayerInteractions.onThornTouched += interactWithHurmfulObjects;
        PlayerInteractions.onFinished += restorePlayerHealth;
    }

    private void OnDisable()
    {
        PlayerInteractions.onThornTouched -= interactWithHurmfulObjects;
        PlayerInteractions.onFinished -= restorePlayerHealth;
    }

    private void interactWithHurmfulObjects()
    {
        if (playerHealth > 1)
        {
            playerHealth--;
        }
        else
        {
            playerHealth = 0;
            AdvancedSceneManager.Instance.RestartCurrentLevel();
            playerHealth = 3;
        }
    }

    private void restorePlayerHealth()
    {
        AdvancedSceneManager.Instance.LoadFirstLevel();
        playerHealth = 3;
    }

    public static int GetPlayerHealth()
    {
        return playerHealth;
    }

    public void LoadData(GameData data)
    {
        playerHealth = data.healthLeft; 
    }

    public void SaveData(ref GameData data)
    {
        data.healthLeft = playerHealth;
    }
}
