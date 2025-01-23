using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f; // Movement speed
    public float boundary = 8f; // Horizontal boundary (adjust based on your screen size)

    void Update()
    {
        // Get horizontal input
        float move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        // Move the basket
        transform.Translate(move, 0, 0);

        // Clamp position to stay within boundaries
        float clampedX = Mathf.Clamp(transform.position.x, -boundary, boundary);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}
