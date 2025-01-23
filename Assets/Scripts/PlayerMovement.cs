using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player
    private Rigidbody2D rb;
    private bool isFacingRight = true; // Track the direction of where the player is facing

    public float radius = 5f; // The radius for circular boundaries
    private Vector2 center = new Vector2(0, 0); // The center of the circle

    public Vector2 minBounds = new Vector2(-5, -5); // Minimum x and y bounds
    public Vector2 maxBounds = new Vector2(5, 5); // Maximum x and y bounds

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    private void Update()
    {
        // Move the player with arrow keys 
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveX, moveY).normalized * moveSpeed;

        // Movement to Rigidbody2D
        rb.velocity = movement;

        // Getting the current position of the player
        Vector2 currentPos = rb.position;

        if (moveX < 0 && !isFacingRight) // Moving right
        {
            Flip();
        }
        else if (moveX > 0 && isFacingRight) // Moving left
        {
            Flip();
        }

        // Clamping to the rectangular boundaries
        float clampedX = Mathf.Clamp(currentPos.x, minBounds.x, maxBounds.x);
        float clampedY = Mathf.Clamp(currentPos.y, minBounds.y, maxBounds.y);

        rb.position = new Vector2(clampedX, clampedY);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight; // Toggle the direction
        Vector3 scale = transform.localScale; // Get the current scale
        scale.x *= -1; // Flip the sprite horizontally
        transform.localScale = scale; // Apply the flipped scale
    }
}
