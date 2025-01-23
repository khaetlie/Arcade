using UnityEngine;

public class Player : MonoBehaviour
{
    void Start()
    {
        // Make sure the player persists across scenes
        DontDestroyOnLoad(gameObject);
    }
}
