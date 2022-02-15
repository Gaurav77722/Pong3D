using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modifier1 : MonoBehaviour
{
    
    private void Start()
    {
        Rigidbody cube = GetComponent<Rigidbody>();
        cube.AddForce(Vector3.forward,ForceMode.Impulse);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Rigidbody cube = GetComponent<Rigidbody>();
        Transform transform = GetComponent<Transform>();

        if (transform.position.z > 5.2)
        {
            cube.AddForce(Vector3.back * 1.5f,ForceMode.Impulse);
        }
        else if (transform.position.z < -5.2)
        {
            cube.AddForce(Vector3.forward * 1.5f,ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Move the ball in the upward direction
        if(other.gameObject.name == "Ball")
        {
            Rigidbody ball = other.gameObject.GetComponent<Rigidbody>();
            ball.AddForce(Vector3.forward * 20f , ForceMode.Impulse);
        }
        

    }
}
