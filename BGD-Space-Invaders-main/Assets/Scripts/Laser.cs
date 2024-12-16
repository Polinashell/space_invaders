using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject explosionPrefab; // Prefab of the explosion effect
    public AudioClip explosionSound;   // Sound effect for explosion

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Log the object we collide with
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        // Check if the object has the tag "Alien"
        if (collision.CompareTag("Alien"))
        {
            Debug.Log("Hit Alien!");

            // Play explosion sound
            if (explosionSound != null)
            {
                AudioSource.PlayClipAtPoint(explosionSound, transform.position);
                Debug.Log("Playing explosion sound!");
            }
            else
            {
                Debug.Log("Explosion sound is missing!");
            }

            // Instantiate explosion effect at the enemy's position
            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, collision.transform.position, Quaternion.identity);
                Debug.Log("Explosion instantiated!");
            }
            else
            {
                Debug.Log("Explosion prefab is missing!");
            }

            // Destroy the alien and the bullet
            Destroy(collision.gameObject); // Destroy the enemy
            Destroy(gameObject);           // Destroy the laser (bullet)
        }
    }
}
