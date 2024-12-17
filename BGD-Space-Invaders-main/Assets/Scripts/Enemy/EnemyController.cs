using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float minPosX;
    public float maxPosX;

    public float moveDistance = 1f;

    bool isMovingRight = true;

    // Variable for tracking the number of destroyed enemies
    private static int enemiesDestroyed = 0;

    // Threshold for number of destroyed enemies after which speed will increase
    public int increaseSpeedThreshold = 5;

    // Speed increase amount (decreasing timeStep to make enemies faster)
    public float speedIncreaseAmount = 0.5f;

    public float timeStep = 1f;
    public float countdown;

    // I added a switch to try both methods
    public bool isUsingCountdown = true;

    // Use this for initialization
    void Start()
    {
        if (isUsingCountdown)
        {
            countdown = timeStep;
        }
        else
        {
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
        // Check if the number of destroyed enemies exceeds the threshold
        if (enemiesDestroyed >= increaseSpeedThreshold)
        {
            // Decrease the timeStep to make the movement faster (increase speed)
            timeStep = Mathf.Max(0.5f, timeStep - speedIncreaseAmount);
            enemiesDestroyed = 0;  // Reset the counter after speed is increased
        }

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

    // Static method to increment the number of destroyed enemies
    public static void EnemyDestroyed()
    {
        enemiesDestroyed++;
    }
}









