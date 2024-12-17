using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public AudioClip destructionSFX;  // Sound to play when the enemy is destroyed

    // Unity calls this function when the Collider on the game object has "Is Trigger" checked.
    // It detects when the enemy collides with a projectile (laser)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("I was triggered!");

        // Check if the collider is a "Laser" (the player's projectile)
        if (collision.CompareTag("Laser"))
        {
            // Destroy the alien game object (enemy)
            Destroy(gameObject);

            // Destroy the projectile (laser) game object
            Destroy(collision.gameObject);

            // Play the destruction sound when the enemy is destroyed
            AudioSource.PlayClipAtPoint(destructionSFX, transform.position);

            // Increment the number of destroyed enemies by calling the EnemyController's method
            EnemyController.EnemyDestroyed();  // This updates the enemiesDestroyed count in EnemyController
        }
    }
}














