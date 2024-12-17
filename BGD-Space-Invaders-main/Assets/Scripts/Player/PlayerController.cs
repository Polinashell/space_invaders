using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    public float limitRight = 0f;
    public float limitLeft = 0f;

    public SpriteRenderer playerSprite;
    private float playerSpriteHalfWidth;

    public float rightScreenEdge;
    public float leftScreenEdge;

    void Start()
    {
        SetupScreenBounds();
    }

    void Update()
    {
        float inputHl = Input.GetAxis("Horizontal");

        // If moving right and the player is within screen bounds
        if (inputHl > 0 && transform.position.x < rightScreenEdge - playerSpriteHalfWidth)
        {
            Vector3 currentPosition = transform.position;
            Vector3 newPosition = currentPosition + new Vector3(1f, 0f);
            transform.position = Vector3.MoveTowards(currentPosition, newPosition, moveSpeed * Time.deltaTime);
        }
        // If moving left and the player is within screen bounds
        else if (inputHl < 0 && transform.position.x > leftScreenEdge + playerSpriteHalfWidth)
        {
            Vector3 currentPosition = transform.position;
            Vector3 newPosition = currentPosition - new Vector3(1f, 0f);
            transform.position = Vector3.MoveTowards(currentPosition, newPosition, moveSpeed * Time.deltaTime);
        }
    }

    void SetupScreenBounds()
    {
        Camera mainCamera = Camera.main;

        // Find the world position of the right screen edge
        Vector2 screenTopRightCorner = new Vector2(Screen.width, Screen.height);
        Vector2 topRightCornerInWorldSpace = mainCamera.ScreenToWorldPoint(screenTopRightCorner);
        rightScreenEdge = topRightCornerInWorldSpace.x;

        // Find the world position of the left screen edge
        Vector2 screenBottomLeftCorner = new Vector2(0f, 0f);
        Vector2 bottomLeftCornerInWorldSpace = mainCamera.ScreenToWorldPoint(screenBottomLeftCorner);
        leftScreenEdge = bottomLeftCornerInWorldSpace.x;

        // Calculate the half-width of the player sprite
        playerSpriteHalfWidth = playerSprite.bounds.size.x / 2f;
    }
}

