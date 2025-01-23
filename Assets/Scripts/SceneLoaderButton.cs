using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneToLoad;  // Name of the scene 

    public void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);  // Load the scene
        }
        else
        {
            Debug.LogWarning("Scene name not set!");
        }
    }
}
