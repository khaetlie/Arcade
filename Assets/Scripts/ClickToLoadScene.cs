using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToLoadScene : MonoBehaviour
{
    public string sceneToLoad = "YourSceneName";  // The name of the scene to load

    void Update()
    {
        if (Input.GetMouseButtonDown(0))  // Left mouse button
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);  
            Collider2D hit = Physics2D.OverlapPoint(mousePosition); 

            if (hit != null && hit.gameObject == gameObject) 
            {
                SceneManager.LoadScene(sceneToLoad);  // Load the specific scene
            }
        }
    }
}
