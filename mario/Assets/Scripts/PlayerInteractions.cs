using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractions : MonoBehaviour
{

    public static Action onCoinTouched;
    public static Action onThornTouched;
    public static Action onFinished;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            onCoinTouched?.Invoke();
        }

        if (collision.gameObject.CompareTag("Thorn"))
        {
            onThornTouched?.Invoke();
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            onFinished?.Invoke();
        }
    }
}
