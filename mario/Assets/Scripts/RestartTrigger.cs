using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RestartTrigger : MonoBehaviour
{
    public UnityEvent RestartTriggerEnter;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            RestartTriggerEnter.Invoke();
        }
    }

}
