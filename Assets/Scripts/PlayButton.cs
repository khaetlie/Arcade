using UnityEngine;
using UnityEngine.SceneManagement;
using System .Collections;

public class PlayButton : MonoBehaviour
{
    public string targetSpawnPointName;

    public void OnStartButtonClicked()
    {
        if (SpawnManager.Instance != null)
        {
            SpawnManager.Instance.targetSpawnPointName = targetSpawnPointName;
        }
        else
        {
            Debug.LogError("SpawnManager instance is null!");
        }

        StartCoroutine(LoadSceneAsync("Instructions"));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
