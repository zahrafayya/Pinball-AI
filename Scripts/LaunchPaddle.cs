using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPaddle : MonoBehaviour
{
    [SerializeField] private Rigidbody ballRigidbody;
    [SerializeField] private Animator anim;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Ball" && anim.GetBool("IsMoved"))
        {
            ballRigidbody.AddForce(Vector3.up * 20, ForceMode.Impulse);
        }

    }
}
