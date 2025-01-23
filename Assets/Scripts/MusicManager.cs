using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioClip defaultMusic;    // The default music for most scenes
    public AudioClip scene1Music;     // Music for Scene 1
    public AudioClip scene2Music;  
    public AudioClip scene3Music;     // Music for Scene 2

    private AudioSource audioSource;

    void Awake()
    {
        // Make sure this GameObject doesn't get destroyed when switching scenes
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();

        // Set the default music
        if (defaultMusic != null)
        {
            audioSource.clip = defaultMusic;
            audioSource.Play();
        }

        // Listen for scene changes
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Arcade")
        {
            ChangeMusic(scene1Music);
        }
        else if (scene.name == "CatchGame")
        {
            ChangeMusic(scene2Music);
        }
        else if (scene.name == "CatchLevel2")
        {
            // Default music for other scenes
            ChangeMusic(scene3Music);
        }
        else
        {
            ChangeMusic(defaultMusic);
        }
    }

    void ChangeMusic(AudioClip newMusic)
    {
        if (newMusic != null && audioSource.clip != newMusic)
        {
            audioSource.clip = newMusic;
            audioSource.Play();
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
