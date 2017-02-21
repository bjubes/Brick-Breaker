using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class moveBall : MonoBehaviour
{

    public float speed = 8f;
    bool clicked = false;

    bool moving = false;

    Rigidbody2D ballRigidBody;
    GameManager gameManager;


    //for coroutine
    List<GameObject> balls;
    Vector3 origPos;
    Vector2 vel;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        ballRigidBody = this.GetComponent<Rigidbody2D>();
        if (ballRigidBody == null)
        {
            Debug.Log("no rigidbody");
        }
    }

    // Update is called once per frame
    void Update()
    {
        clicked = Input.GetMouseButtonDown(0);

        if (transform.position.y <= (-4.9 + 1 / 8))
        {
            moving = false;
            ballRigidBody.velocity = Vector2.zero;
            transform.position = new Vector2(transform.position.x, (-4.9f + 1.0f / 8.0f));
            gameManager.TurnEnded();
        }

    }

    void FixedUpdate()
    {

        if (moving)
        {
            ballRigidBody.velocity = ballRigidBody.velocity.normalized * speed;
        }
    }

    public void MoveBall(Vector2 dir)
    {
        if (moving)
        {
            return;
        }

        ballRigidBody.velocity = dir.normalized * speed;
        moving = true;

        balls = gameManager.dumbBallList;
        origPos = transform.position;
        vel = ballRigidBody.velocity;

        StartCoroutine("SpawnBalls");

    }

    IEnumerator SpawnBalls()
    {
        foreach (GameObject ball in balls)
        {
            ball.transform.position = origPos;
            ball.GetComponent<Rigidbody2D>().velocity = vel;
            ball.SetActive(true);
            print("ball made");
            for (int i = 0; i < 10; i++)
            {
                yield return null;
            }
        }
    }

}
