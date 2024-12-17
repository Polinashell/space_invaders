using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float minPosX;
    public float maxPosX;

    public float moveDistance = 1f;
    bool isMovingRight = true;

    // Variables for managing enemy speed and movement
    public float timeStep = 1f; // Time step for movement speed
    public float countdown; // Countdown timer for movement
    public bool isUsingCountdown = true; // Option to use countdown timer

    // Use this for initialization
    void Start()
    {
        if (isUsingCountdown)
        {
            countdown = timeStep;
        }
        else
        {   
            // Repeatedly call Move() at intervals defined by timeStep
            InvokeRepeating("Move", timeStep, timeStep);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isUsingCountdown)
        {
            countdown -= Time.deltaTime;

            if (countdown <= 0)
            {
                Move();
                countdown = timeStep;
            }
        }
    }

    void Move()
    {
        if (isMovingRight)
        {
            // Moving right
            Vector3 currentPos = transform.position;
            Vector3 newPos = currentPos + new Vector3(moveDistance, 0f);
            transform.position = newPos;

            // If aliens group reached the right-most edge, flip their direction
            if (transform.position.x >= maxPosX)
            {
                isMovingRight = false;
            }
        }
        else
        {
            // Moving left
            Vector3 currentPos = transform.position;
            Vector3 newPos = currentPos - new Vector3(moveDistance, 0f);
            transform.position = newPos;

            // If aliens group reached the left-most edge, flip their direction
            if (transform.position.x <= minPosX)
            {
                isMovingRight = true;
            }
        }
    }
}






