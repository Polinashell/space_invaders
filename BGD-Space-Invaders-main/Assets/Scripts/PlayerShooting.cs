using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // The bullet prefab
    public Transform firePoint;     // Point where the bullet will spawn
    public float bulletSpeed = 10f; // Speed of the bullet

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Check if Space key is pressed
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instantiate the bullet at the firePoint position
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        
        // Add upward velocity to the bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * bulletSpeed;
    }
}
