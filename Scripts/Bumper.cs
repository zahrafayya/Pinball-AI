using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private float bounciness;
    private float _bounceForce;
    private Rigidbody _ballRigidbody;

    private void Start()
    {
        _bounceForce = transform.localScale.x;
        _ballRigidbody = ball.GetComponent<Rigidbody>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Vector3 direction = transform.localPosition - ball.transform.localPosition;

            _ballRigidbody.AddForce(direction * _bounceForce * bounciness);
        }
    }
}
