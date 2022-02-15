using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 force;
    Vector3 currentVelocity = Vector3.zero;
    Vector3 angularVelocity = Vector3.zero;

    private Vector3 green;
    private Vector3 blue;
    
    public ScoreBoardUI scoreBoardGreen;
    public ScoreBoardUIBlue scoreBoardBlue;
    public int greenScore;
    public int blueScore;
    
    public Material orange;
    private void Awake()
    {
        GameObject paddleGreen = GameObject.Find("LPaddle");
        green = paddleGreen.GetComponent<Renderer>().bounds.size;
        
        GameObject paddleBlue = GameObject.Find("RPaddle");
        blue = paddleBlue.GetComponent<Renderer>().bounds.size;
    }

    void Start()
    {
        Rigidbody ball = GetComponent<Rigidbody>();
        ball.AddForce(force,ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody ball = GetComponent<Rigidbody>();
        if (ball.transform.position == new Vector3(0f, 0.2f, 0f))
        {
            ball.transform.position = new Vector3(0f, 0.21f, 0f);
            ball.velocity = currentVelocity;
            ball.angularVelocity = angularVelocity;
            ball.AddForce(force,ForceMode.Impulse);
            
            
            GameObject ballObj = GameObject.Find("Ball");
            ballObj.GetComponent<MeshRenderer>().material = orange;
            
            GameObject paddleGreen = GameObject.Find("LPaddle");
            paddleGreen.transform.localScale = green;
            
            GameObject paddleBlue = GameObject.Find("RPaddle");
            paddleBlue.transform.localScale = blue;
        }
        
    
        scoreBoardGreen = GameObject.Find("Left").GetComponent<ScoreBoardUI>();
        scoreBoardBlue = GameObject.Find("Right").GetComponent<ScoreBoardUIBlue>();
        if (scoreBoardGreen.getScoreGreen() > scoreBoardBlue.getScoreBlue())
        {
            scoreBoardGreen.changeColor();
        }
        else if (scoreBoardGreen.getScoreGreen() < scoreBoardBlue.getScoreBlue())
        {
            scoreBoardBlue.changeColor();
        }
        else if (scoreBoardGreen.getScoreGreen() == scoreBoardBlue.getScoreBlue())
        {
            scoreBoardGreen.changeColorWhite();
            scoreBoardBlue.changeColorWhite();
        }
    
    }
}
