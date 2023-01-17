using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class move_frog : MonoBehaviour
{
    public float jumpForce = 2.0f;
    public float jumpDuration = 2.0f;
    private Rigidbody rb;
    private bool frogOnTheGround = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
    }

    void Update()
    {
        int randomNumber = Random.Range(0, 100);
        if (randomNumber < 3)
        {
            Jump();
        }
    }

    void Jump()
    {
        if (frogOnTheGround) {
            rb.AddForce(new Vector3(0,jumpForce, 0), ForceMode.Impulse);
            frogOnTheGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            frogOnTheGround = true;
        }
    }
}
