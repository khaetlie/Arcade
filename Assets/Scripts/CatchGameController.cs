using UnityEngine;
using UnityEngine.SceneManagement;

public class CatchGameController : MonoBehaviour
{
    public ScoreManager scoreManager;
    public GameOverManager gameOverManager;

    private int itemsCaught = 0;  // Items successfully caught
    private int missedItems = 0; // Items missed by the player
    private int maxMissedItems = 5; // Max missed items allowed in Level 1
    private int targetItems; // Target items to catch for current level

    void Start()
    {
        // Set the target items and max missed items based on the current level
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "CatchGame")
        {
            targetItems = 20; // Items to catch in Level 1
            maxMissedItems = 5; // Max missed items allowed in Level 1
        }
        else if (currentScene == "CatchLevel2")
        {
            targetItems = 40; // Items to catch in Level 2
            maxMissedItems = 3; // Max missed items allowed in Level 2
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food"))
        {
            // Item caught logic
            scoreManager.IncreaseScore(1);
            itemsCaught++;
            Destroy(other.gameObject);

            // Check if target items are caught
            if (itemsCaught >= targetItems)
            {
                if (SceneManager.GetActiveScene().name == "CatchGame")
                {
                    StartLevel2(); // Go to Level 2
                }
                else
                {
                    gameOverManager.WinGame(); // Player wins the game
                }
            }
        }
    }

    public void MissItem()
    {
        missedItems++;
        gameOverManager.IncrementMissedItems();

        if (missedItems >= maxMissedItems)
        {
            gameOverManager.GameOver(); // Trigger game over
        }
    }

    private void StartLevel2()
    {
        SceneManager.LoadScene("CatchLevel2"); // Transition to Level 2
    }
}
