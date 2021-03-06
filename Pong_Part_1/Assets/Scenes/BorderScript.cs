using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderScript : MonoBehaviour
{
    public int scoreGreen;
    public int scoreBlue;
    public activePaddle player;

    public ScoreBoardUI scoreBoard;
    public ScoreBoardUIBlue scoreBoardBlue;

    private void Start()
    {
        scoreBoard = GameObject.Find("Left").GetComponent<ScoreBoardUI>();
        scoreBoardBlue = GameObject.Find("Right").GetComponent<ScoreBoardUIBlue>();
    }

    void OnCollisionEnter(Collision collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        ball.transform.position = new Vector3(0f, 0.2f, 0f);
        
        
        if (player == activePaddle.Green)
        {
            scoreGreen++;
            scoreBoard.increaseGreen();
            Debug.Log("Player Green:" + scoreGreen);
        }
        else if (player == activePaddle.Blue)
        {
            scoreBlue++;
            scoreBoardBlue.increaseBlue();
            Debug.Log("Player Blue:" + scoreBlue);
        }
        
        // Win Condition
        if (scoreBlue == 11)
        {
            Debug.Log("Game Over, Right Paddle Wins");
            scoreBlue = 0;
            scoreGreen = 0;
        }
        else if(scoreGreen == 11)
        {
            Debug.Log("Game Over, Left Paddle Wins");
            scoreBlue = 0;
            scoreGreen = 0;
        }
    }
}
