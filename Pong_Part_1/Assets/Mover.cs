using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float movementPerSecond = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movementAxis = Input.GetAxis("Horizontal");
        // Transform transform = GetComponent<Transform>();

        Vector3 force = Vector3.right * movementAxis * movementPerSecond * Time.deltaTime;

        Rigidbody rbody = GetComponent<Rigidbody>();
        if (rbody)
        {
            rbody.AddForce(force, ForceMode.VelocityChange);
        }

        // transform.position += Vector3.right * movementAxis * movementPerSecond * Time.deltaTime;

        // if (Input.GetKey(KeyCode.A))
        // {
        //     Transform transform = GetComponent<Transform>();
        //     transform.position += -Vector3.right * movementPerSecond * Time.deltaTime;
        // }
        //
        // if (Input.GetKey(KeyCode.D))
        // {
        //     Transform transform = GetComponent<Transform>();
        //     transform.position += Vector3.right * movementPerSecond * Time.deltaTime;
        // }
    }

    private void OnCollisionEnter(Collision collision)
    {
        BoxCollider bbox = GetComponent<BoxCollider>();
        float xCenter = bbox.bounds.center.x;

        Debug.Log("Center at " + xCenter + "collided object at " + collision.transform.position.x);

        Vector3 newVector = Quaternion.Euler(0f, 0f, 45f) * Vector3.up;

        Debug.DrawLine(transform.position, transform.position + newVector * 10f, Color.red);
        Debug.Break();
    }
}
