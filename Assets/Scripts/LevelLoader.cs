using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
        
    [SerializeField] float splashScreenDelay = 3f;

    public static LevelLoader instance;
    AudioPlayer audioPlayer;
    int currentLevel = 1;
    
    void Awake() {
        SetupSingleton();
    }

    void SetupSingleton() {
        if (instance != null) {
            gameObject.SetActive(false);
            Destroy(this);
        }
        else {
            instance = this;
            DontDestroyOnLoad(this);
            audioPlayer = FindObjectOfType<AudioPlayer>();
        }
    }
    
    void Start() {
        if (SceneManager.GetActiveScene().name == "Splash") LoadMainMenuWithDelay();
    }

    public void ReloadCurrentLevel() {
        Time.timeScale = 1f;
        string level = "Level " + currentLevel;
        SceneManager.LoadScene(level);
        FindObjectOfType<AudioPlayer>().PlayLevelStartSound();
    }
    
    public void LoadLevel(int levelNumber) {
        string level = "Level " + levelNumber;
        SceneManager.LoadScene(level);
        FindObjectOfType<AudioPlayer>().PlayLevelStartSound();
    }

    public void LoadNextLevel() {
        currentLevel += 1;
        string level = "Level " + currentLevel;
        SceneManager.LoadScene(level);
        FindObjectOfType<AudioPlayer>().PlayLevelStartSound();
    }
    
    public void LoadGameOver() {
        SceneManager.LoadScene("Game Over");
        FindObjectOfType<AudioPlayer>().PlayFailureSound();
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void LoadMainMenu() {
        Time.timeScale = 1f;
        StartCoroutine(WaitToLoadMainMenu(false));
    }

    public void LoadMainMenuWithDelay() {
        StartCoroutine(WaitToLoadMainMenu(true));
    }

    IEnumerator WaitToLoadMainMenu(bool shouldDelay) {
        if (shouldDelay) yield return new WaitForSeconds(splashScreenDelay);
        SceneManager.LoadScene("Menu");
        audioPlayer.PlayMenuLoadedSound();
    }

    public void LoadOptions() {
        SceneManager.LoadScene("Options");
    }
}
