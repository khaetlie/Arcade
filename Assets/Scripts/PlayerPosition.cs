using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.HasKey("SpawnX") && PlayerPrefs.HasKey("SpawnY") && PlayerPrefs.HasKey("SpawnZ"))
        {
            float x = PlayerPrefs.GetFloat("SpawnX");
            float y = PlayerPrefs.GetFloat("SpawnY");
            float z = PlayerPrefs.GetFloat("SpawnZ");

            transform.position = new Vector3(x, y, z);

            PlayerPrefs.DeleteKey("SpawnX");
            PlayerPrefs.DeleteKey("SpawnY");
            PlayerPrefs.DeleteKey("SpawnZ");
        }

        // Find the CameraFollow script and assign the player
        CameraFollow cameraFollow = Camera.main.GetComponent<CameraFollow>();
        if (cameraFollow != null)
        {
            cameraFollow.AssignPlayer(gameObject); // Assign this player to the camera
        }
    }
}
