using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    public string targetSpawnPointName; // Name of the spawn point to use
    public GameObject playerPrefab;

  
    private void Start()
    {
        SpawnPlayerAtTarget();
    }

    public void SetTargetSpawnPoint(string spawnPointName)
    {
        targetSpawnPointName = spawnPointName;
    }

    private void SpawnPlayerAtTarget()
    {
        // Find the target spawn point in the current scene
        GameObject targetSpawnPoint = GameObject.Find(targetSpawnPointName);
        if (targetSpawnPoint != null)
        {
            // Spawn the player prefab at the target spawn point's position
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player == null) // If player is not already instantiated
            {
                player = Instantiate(playerPrefab, targetSpawnPoint.transform.position, Quaternion.identity);
                player.tag = "Player";
            }
            else
            {
                // Move existing player to the target spawn point
                player.transform.position = targetSpawnPoint.transform.position;
            }

            Debug.Log($"Player successfully moved to spawn point: {targetSpawnPointName}");
        }
        else
        {
            Debug.LogError($"Target spawn point '{targetSpawnPointName}' not found in the scene!");
        }
    }
}
