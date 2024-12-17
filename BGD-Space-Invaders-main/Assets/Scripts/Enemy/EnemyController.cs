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

    public float timeStep = 1f;  // Initial speed (time between moves)
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
            InvokeRepeating("Move", timeStep, timeStep);  // Initial move
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isUsingCountdown)
        {
            countdown -= Time.deltaTime;  // Countdown method, decreasing time

            if (countdown <= 0)
            {
                Move();  // Move the enemy
                countdown = timeStep;  // Reset countdown with the new timeStep
            }
        }
    }

    void Move()
    {
        // Check if the number of destroyed enemies exceeds the threshold
        if (enemiesDestroyed >= increaseSpeedThreshold)
        {
            timeStep = Mathf.Max(0.5f, timeStep - speedIncreaseAmount);  // Reduce the timeStep (increase speed)
            enemiesDestroyed = 0;  // Reset the counter after speed is increased
            Debug.Log("Speed Increased! New TimeStep: " + timeStep); // Debug to verify speed change

            // Cancel the previous InvokeRepeating and restart it with the updated timeStep
            CancelInvoke("Move");  
            InvokeRepeating("Move", timeStep, timeStep);  // Start new InvokeRepeating with the updated timeStep
        }

        // Enemy movement code
        if (isMovingRight)
        {
            Vector3 currentPos = transform.position;
            Vector3 newPos = currentPos + new Vector3(moveDistance, 0f);
            transform.position = newPos;

            if (transform.position.x >= maxPosX)
            {
                isMovingRight = false;
            }
        }
        else
        {
            Vector3 currentPos = transform.position;
            Vector3 newPos = currentPos - new Vector3(moveDistance, 0f);
            transform.position = newPos;

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
        Debug.Log("Destroyed enemies: " + enemiesDestroyed); // Debug to track destroyed enemies
    }
}























