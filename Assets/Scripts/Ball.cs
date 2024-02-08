using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameManager gameManager;
    public Rigidbody2D rigid2d;
    public float InitialAngleMax = 0.67f;
    public float moveSpeed = 1f;
    public float startX = 0f;
    public float maxStartY = 4;

    // Start is called before the first frame update
    void Start()
    {
        InitialForce();
    }

    void InitialForce()
    {
        Vector2 dir;

        if(Random.value < 0.5f){
            dir = Vector2.right;
        }else{
            dir = Vector2.left;
        }

        dir.y = Random.Range(-InitialAngleMax,InitialAngleMax);
        rigid2d.velocity = dir * moveSpeed;
    }

    void ResetBall()
    {
        float positionY = Random.Range(-maxStartY,maxStartY);
        Vector2 position = new Vector2(startX,positionY);
        transform.position = position;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreZoneL scoreZone = collision.GetComponent<ScoreZoneL>();
        if(scoreZone != null){
            if(gameManager.scorePlayer1 == 11){
                Debug.Log("Left Paddle Wins! Resetting Score...");
                gameManager.scorePlayer1 = 0;
                gameManager.scorePlayer2 = 0;
            }
            if(gameManager.scorePlayer2 == 11){
                Debug.Log("Right Paddle Wins! Resetting Score...");
                gameManager.scorePlayer1 = 0;
                gameManager.scorePlayer2 = 0;
            }
            gameManager.OnScoreZoneReached(scoreZone.id);

            if(scoreZone.id == 2){
                Debug.Log("Player 2 Scored, Score: " + gameManager.scorePlayer1 + "-" + gameManager.scorePlayer2);
            }

            if(scoreZone.id == 1){
                Debug.Log("Player 1 Scored, Score: " + gameManager.scorePlayer1 + "-" + gameManager.scorePlayer2);
            }

            ResetBall();
            InitialForce();


        }
    }
}
