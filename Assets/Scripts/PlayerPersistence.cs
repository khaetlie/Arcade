using UnityEngine;

public class PlayerPersistence : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        if (players.Length > 1)
        {
            Destroy(gameObject); // Destroy duplicates
        }
        else
        {
            DontDestroyOnLoad(gameObject); // Persist between scenes
        }
    }
}
