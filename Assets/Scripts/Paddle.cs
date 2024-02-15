using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public Rigidbody2D rigid2d;
    public int id; 
    public float moveSpeed = 2f;

    public void Update()
    {
        float movement = ProcessInput();
        Move(movement);
    }

    public float ProcessInput()
    {
        float movement = 0f;
        switch(id){
            case 1:
                movement= Input.GetAxis("MovePlayer1");
                break;

            case 2:
                movement = Input.GetAxis("MovePlayer2");
                break; 
        }

        return movement;
    }

    public void Move(float movement)
    {
        Vector2 velo = rigid2d.velocity;
        velo.y = moveSpeed * movement;
        rigid2d.velocity = velo;
    }

}
