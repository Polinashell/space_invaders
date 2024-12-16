using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Bullet prefab
    public Transform firePoint;     // Fire point position
    public float bulletSpeed = 10f; // Bullet speed
    public AudioClip shootSound;    // Sound effect for shooting

    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Fire when space is pressed
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instantiate the bullet at firePoint position
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // Set bullet velocity
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * bulletSpeed;

        // Play shoot sound
        audioSource.PlayOneShot(shootSound);
    }
}
