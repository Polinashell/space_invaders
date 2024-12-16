using UnityEngine;

public class Laser : MonoBehaviour
{
    public AudioClip explosionSound; // Sound effect for explosion

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        if (collision.CompareTag("Alien"))
        {
            Debug.Log("Hit Alien!");

            // Test if this block is reached
            Debug.Log("Trying to play explosion sound...");

            if (explosionSound != null)
            {
                Debug.Log("Playing explosion sound!");
                AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            }
            else
            {
                Debug.Log("Explosion sound is missing!");
            }

            Destroy(collision.gameObject); // Destroy the alien
            Destroy(gameObject);           // Destroy the laser (bullet)
        }
    }
}
