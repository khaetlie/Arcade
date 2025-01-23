using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player
    public Vector3 offset;   // offset between player and the camera
    public float smoothSpeed = 0.125f;
    public float fixedYPosition; 


    
    void LateUpdate()
    {
        if (player != null)
        {
            // Only update the x position to follow the player
            Vector3 desiredPosition = new Vector3(player.position.x + offset.x, fixedYPosition + offset.y, offset.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            
            transform.position = smoothedPosition;

            transform.position = new Vector3(transform.position.x, fixedYPosition, -10);
        }
    }

    public void AssignPlayer(GameObject newPlayer)
{
    player = newPlayer.transform;
}
}


