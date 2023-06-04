using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray : MonoBehaviour
{
    [SerializeField] private Transform groundCheck;
    void Update()
    {
        Debug.DrawRay(transform.position, transform.right * 10, Color.red, 0.1f);
    }
}
