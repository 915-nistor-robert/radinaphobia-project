using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_movement : MonoBehaviour
{
    public float xMin = 0f, xMax = 10, zMin = 0f, zMax=10; // define the range of the 
    public float speed = 2;
    private Rigidbody rb;
    private float timeToMove = 2f;
    private float timeElapsed = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update() {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= timeToMove) {
            float x = Random.Range(xMin, xMax);
            float z = Random.Range(zMin, zMax);
            Vector3 direction = new Vector3(x, 0, z);
            // rb.velocity = new Vector3(5, 0, 0);
            rb.AddForce(direction * speed);
            rb.angularVelocity = Vector3.zero;
            timeElapsed = 0;
        }
    }
}
