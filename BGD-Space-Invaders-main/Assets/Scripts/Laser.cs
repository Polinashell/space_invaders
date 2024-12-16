using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject explosionPrefab; // Prefab for explosion effect
    public AudioClip explosionSound;   // Sound effect for explosion

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object has the tag "Alien"
        if (collision.CompareTag("Alien"))
        {
            // Add points to the score
            ScoreManager.instance.AddScore(10);

            // Instantiate explosion effect
            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, collision.transform.position, Quaternion.identity);
            }

            // Play explosion sound
            if (explosionSound != null)
            {
                AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            }

            // Destroy the enemy (Alien) and the bullet (Laser)
            Destroy(collision.gameObject); // Destroy the Alien
            Destroy(gameObject);           // Destroy the Laser
        }
    }
}
