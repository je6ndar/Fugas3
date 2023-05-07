using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsCollector : MonoBehaviour
{
    public int coinsCollected = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            coinsCollected++;
            Debug.Log("CoinsCollected" + " " + coinsCollected);
            Destroy(collision.gameObject);
        }
    }
}
