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

        if (gameObject.tag == "Spawner")
        {
            bounciness = Random.Range(10f, 120f);
            Debug.Log(bounciness);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        _ballRigidbody.AddForce(Vector3.up * bounciness, ForceMode.Impulse);
    }
}
