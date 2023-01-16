using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_frog : MonoBehaviour
{
    public float jumpForce = 2.0f;
    public float jumpDuration = 2.0f;
    private Rigidbody rb;
    private bool fronOnTheGround = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
    }

    void Update()
    {
        Jump();
    }

    void Jump()
    {
        if (fronOnTheGround) {
            rb.AddForce(new Vector3(0,jumpForce, 0), ForceMode.Impulse);
            fronOnTheGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            fronOnTheGround = true;
        }
    }
}
