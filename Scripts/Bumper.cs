using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    private float _bounceForce;
    private Rigidbody _ballRigidbody;

    private void Start()
    {
        _bounceForce = transform.localScale.x;
        _ballRigidbody = ball.GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 direction = transform.localPosition - ball.transform.localPosition;
        direction.Normalize();

        _ballRigidbody.AddForce(direction * _bounceForce * 8, ForceMode.Impulse);
    }
}
