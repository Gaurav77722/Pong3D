using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Modifier2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody cube = GetComponent<Rigidbody>();
        cube.AddForce(Vector3.back,ForceMode.Impulse);
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
        // Change Size of Paddle
        if(other.gameObject.name == "Ball")
        {
            Ball ball = other.gameObject.GetComponent<Ball>();
            Debug.Log(ball.GetComponent<MeshRenderer>().material.name);
            
            // If Ball is Green
            if (ball.GetComponent<MeshRenderer>().material.name == "Green (Instance)")
            {
                GameObject paddleBlue = GameObject.Find("RPaddle");
                Vector3 scaleChangeBlue = new Vector3(0f, 0f, -1.2f);
                paddleBlue.transform.localScale += scaleChangeBlue;
            }
            // If Ball is Blue
            else if (ball.GetComponent<MeshRenderer>().material.name == "Blue (Instance)")
            {
                GameObject paddleGreen = GameObject.Find("LPaddle");
                Vector3 scaleChangeGreen = new Vector3(0f, 0f, -1.2f);
                paddleGreen.transform.localScale += scaleChangeGreen;
            }
        }

    }
}
