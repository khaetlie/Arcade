using UnityEngine;
using UnityEngine.UI; // Make sure to include this for UI Text

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // UI Text reference to display score
    private int score = 0;

    void Start()
    {
        // Initialize the score display
        UpdateScoreText();
    }

    // Method to increase the score
    public void IncreaseScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    // Method to update the score in the UI
    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    
}
