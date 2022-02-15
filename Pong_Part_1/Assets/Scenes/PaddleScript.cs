using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum activePaddle
{
    Green,Blue
}
public class PaddleScript : MonoBehaviour
{
    
    public activePaddle player;
    public float movementPerSecond = 1f;
    
    public AudioSource audioSrc;

    public AudioClip audioToPlayUp;
    public AudioClip audioToPlayDown;
    
    // Start
    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Transform transform = GetComponent<Transform>();
        float movementAxis = 0f;
        if (player == activePaddle.Green)
        {
            movementAxis = Input.GetAxisRaw("PlayerGreen");
        }
        else if(player == activePaddle.Blue)
        {
            movementAxis = Input.GetAxisRaw("PlayerBlue");
        }
        transform.position += Vector3.forward * movementAxis * movementPerSecond * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision ball)
    {
        // Paddle Hit
        if (ball != null)
        {
            var paddleBounds = GetComponent<BoxCollider>().bounds;
            float maxPaddleHeight = paddleBounds.max.z;
            float minPaddleHeight = paddleBounds.min.z;

            float percentHeight = (ball.transform.position.z - minPaddleHeight) / (maxPaddleHeight - minPaddleHeight);
            float bounceDirection = (percentHeight - 0.5f) / 0.5f;

            Vector3 currentVelocity = ball.relativeVelocity;
            float newSign = currentVelocity.x > 0 ? -1f : 1f;
            float newRotSign = newSign < 0f ? 1f : -1f;
            float newSpeed = currentVelocity.magnitude * 1.1f;
            Vector3 newVelocity = new Vector3(newSign, 0f, 0f) * newSpeed;
            newVelocity = Quaternion.Euler(0f, newRotSign * 60f * bounceDirection, 0f) * newVelocity;

            ball.rigidbody.velocity = newVelocity;
            
            // Audio
            Renderer rend = GetComponent<Renderer>();
            float middle = rend.bounds.center.z;
            
            // Upper Half of Paddle
            if (ball.transform.position.z > middle)
            {
                audioSrc.clip = audioToPlayUp;
                audioSrc.Play();
            }
            // Lower Half of Paddle
            else if (ball.transform.position.z < middle)
            {
                audioSrc.clip = audioToPlayDown;
                audioSrc.Play();
            }
        }// End of If
    }// End of OnCollision
    
}
