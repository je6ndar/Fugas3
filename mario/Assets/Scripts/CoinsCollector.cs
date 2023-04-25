using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsCollector : MonoBehaviour
{
    public int coinsCollected = 0;
    public Text coinsCollectedText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            coinsCollected++;
            coinsCollectedText.text = "Coins Collected: " + coinsCollected.ToString();
            Destroy(collision.gameObject);
        }
    }
}
