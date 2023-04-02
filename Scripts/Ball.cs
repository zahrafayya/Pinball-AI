using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    [Header("Events")] public GameEvent onBallCollide;
    [Header("Events")] public GameEvent onBallVoid;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Void")
        {
            Debug.Log("oops");
            onBallVoid.Raise();
        }
        else
        {
            Debug.Log("yay");
            onBallCollide.Raise();
        }
    }
}
