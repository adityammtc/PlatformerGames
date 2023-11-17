using UnityEngine;
using UnityEngine.SceneManagement; 
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioClip[] levelMusicClips; 
    private AudioSource backgroundMusic;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayLevelMusic(scene.buildIndex); 
    }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            backgroundMusic = GetComponent<AudioSource>();

            if (backgroundMusic == null)
            {
                backgroundMusic = gameObject.AddComponent<AudioSource>();
                backgroundMusic.loop = true;
            }

            
            if (levelMusicClips.Length > 0)
            {
                PlayLevelMusic(0); 
            }
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Fungsi untuk memainkan musik untuk level tertentu
    public void PlayLevelMusic(int levelIndex)
    {
        if (levelIndex < levelMusicClips.Length)
        {
            AudioClip clipToPlay = levelMusicClips[levelIndex];
            if (backgroundMusic.clip != clipToPlay)
            {
                backgroundMusic.clip = clipToPlay;
                backgroundMusic.Play();
            }
        }
        else
        {
            Debug.LogWarning("No clip found for level index: " + levelIndex);
        }
    }
}
