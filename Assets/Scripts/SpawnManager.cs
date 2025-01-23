using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        // Find the player by tag
        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.LogError("Player not found in the scene!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (player != null)
            {
                // Move player to this spawn point's position
                player.transform.position = transform.position;
            }
            else
            {
                Debug.LogError("Player object is not assigned properly.");
            }
        }
    }
}
