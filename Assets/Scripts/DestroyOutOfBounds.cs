using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float lowerBound = -5f; // Adjust based on the screen's bottom

    void Update()
    {
        if (transform.position.y < lowerBound)
        {
            Destroy(gameObject);
        }
    }
}
