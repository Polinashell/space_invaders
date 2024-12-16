using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 0.5f); // Destroy explosion after 0.5 seconds
    }
}
