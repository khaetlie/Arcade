using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public Text scoreText;
    public Text missedText;
    public GameObject gameOverPanel;

    private int missedItems = 0;
    private int score = 0;

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        scoreText.text = "Score: " + score;
        missedText.text = "Missed Items: " + missedItems;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void WinGame()
{
    gameOverPanel.SetActive(true); // Show the game over panel for the win
    scoreText.text = "You Win!\nFinal Score: " + score;
}

    public void QuitGame()
    {
        Application.Quit();
    }

    public void IncrementMissedItems()
    {
        missedItems++;
    }

    public void UpdateScore(int points)
    {
        score += points;
    }
}
