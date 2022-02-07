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
}
