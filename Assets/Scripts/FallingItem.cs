using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FallingItem : MonoBehaviour
{
    [SerializeField] GameObject[] itemPrefabs;
    [SerializeField] float spawnInterval = 1f;
    [SerializeField] float minX = -6f;
    [SerializeField] float maxX = 6f;
    [SerializeField] float spawnY = 4f;
    [SerializeField] Text scoreText;
    [SerializeField] Text missedText;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] float fallSpeed = 3f;

    private int score = 0;
    private int missCount = 0;
    private bool gameOver = false;
    private int targetScore;
    private int maxMissedItems;

    void Start()
    {
        gameOverPanel?.SetActive(false);

        // Configure settings for each level
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "CatchGame") // Level 1
        {
            targetScore = 20;
            maxMissedItems = 5;
        }
        else if (currentScene == "CatchLevel2") // Level 2
        {
            targetScore = 25;
            maxMissedItems = 3;
            fallSpeed = 4.5f;  // Faster speed
            spawnInterval = 0.7f; // Shorter interval
        }

        StartCoroutine(SpawnItems());
    }

    IEnumerator SpawnItems()
    {
        while (!gameOver)
        {
            float randomX = Random.Range(minX, maxX);
            Vector3 spawnPosition = new Vector3(randomX, spawnY, 0);

            if (itemPrefabs.Length > 0)
            {
                GameObject item = Instantiate(itemPrefabs[Random.Range(0, itemPrefabs.Length)], spawnPosition, Quaternion.identity);

                // Make item fall
                while (item != null && item.transform.position.y > -3f)
                {
                    item.transform.position += Vector3.down * (fallSpeed * Time.deltaTime);
                    yield return null;
                }

                // Missed item
                if (item != null)
                {
                    MissedItem();
                    Destroy(item);
                }
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void MissedItem()
{
    missCount++;
    missedText.text = "Missed: " + missCount;

    // Notify the CatchGameController
    FindObjectOfType<CatchGameController>().MissItem();

    if (missCount >= maxMissedItems)
    {
        GameOver();
    }
}


    public void CaughtItem()
    {
        score++;
        scoreText.text = "Score: " + score;

        if (score >= targetScore)
        {
            if (SceneManager.GetActiveScene().name == "CatchGame")
            {
                LoadNextLevel();
            }
            else
            {
                WinGame();
            }
        }
    }

    private void GameOver()
    {
        gameOver = true;
        gameOverPanel?.SetActive(true);
        StopAllCoroutines();
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene("CatchLevel2"); // Load Level 2
    }

    private void WinGame()
    {
        gameOver = true;
        Debug.Log("You Win!");
        StopAllCoroutines();
        // Optionally, load a "You Win" scene or display a win screen
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart current level
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        SceneManager.LoadScene("Arcade");
    }
}
