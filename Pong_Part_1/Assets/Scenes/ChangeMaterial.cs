using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public activePaddle player;
    public Material green;
    public Material blue;

    private void OnCollisionEnter(Collision collision)
    {
        if (player == activePaddle.Blue)
        {
            Ball ball = collision.gameObject.GetComponent<Ball>();
            if(ball!=null){
                ball.GetComponent<MeshRenderer>().material = blue;
            }
        }
        else if(player == activePaddle.Green)
        {
            Ball ball = collision.gameObject.GetComponent<Ball>();
            if (ball != null)
            {
                ball.GetComponent<MeshRenderer>().material = green;
            }
        }
    }
}
