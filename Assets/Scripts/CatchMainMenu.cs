using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Load the main game scene
        SceneManager.LoadScene("CatchGame");
    }

    public void QuitToArcade()
    {
        // Load the arcade scene
        SceneManager.LoadScene("Arcade");
    }
}

