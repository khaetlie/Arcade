using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public string targetSpawnPointName; // Name of the spawnpoint for the next scene

    public void OnStartButtonClicked()
    {
        if (SpawnManager.Instance != null)
        {
            // Set the target spawn point 
            SpawnManager.Instance.targetSpawnPointName = targetSpawnPointName;
        }

        // Load the specific scene
        SceneManager.LoadScene("NewHouseExterior");
    }
}

