using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private float bounciness;
    private Rigidbody _ballRigidbody;

    private void Start()
    {
        _ballRigidbody = ball.GetComponent<Rigidbody>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            _ballRigidbody.AddForce(transform.up * bounciness);
        }
    }
}
