using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHud : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI UICoins;
    [SerializeField] Image Heart1;
    [SerializeField] Image Heart2;
    [SerializeField] Image Heart3;

    private int coinsCollected = 0;

    private void OnEnable()
    {
        PlayerInteractions.onCoinTouched += UICoinsCounter;
        PlayerInteractions.onThornTouched += UILivesLeft;
    }
    
    private void OnDisable()
    {
        PlayerInteractions.onCoinTouched -= UICoinsCounter;
        PlayerInteractions.onThornTouched -= UILivesLeft;
    }

    private void UICoinsCounter()
    {
        coinsCollected++;
        UICoins.SetText(coinsCollected.ToString());
    }

    private void UILivesLeft()
    {
        if (PlayerStats.GetPlayerHealth() == 3) 
            Heart3.gameObject.SetActive(false);
        if (PlayerStats.GetPlayerHealth() == 2)
            Heart2.gameObject.SetActive(false);
        if (PlayerStats.GetPlayerHealth() == 1)
            Heart1.gameObject.SetActive(false);
    }
}
