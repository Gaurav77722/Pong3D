using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 force;
    void Start()
    {
        Rigidbody ball = GetComponent<Rigidbody>();
        ball.AddForce(force,ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
