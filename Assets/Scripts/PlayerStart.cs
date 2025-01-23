using UnityEngine;

public class PlayerStart : MonoBehaviour
{
    public GameObject spawnPoint;  // Assign the GameObject (not just Transform)

void Start() {
    if (spawnPoint != null)
    {
        transform.position = spawnPoint.transform.position;  // Access the position of the GameObject
    }
        else
        {
            Debug.LogError("Spawn point not assigned!");
        }
    }
}
