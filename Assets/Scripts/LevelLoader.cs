using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
    
    [SerializeField] float splashScreenDelay = 3f;

    AudioPlayer audioPlayer;

    public static LevelLoader instance;

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

    public void LoadLevel() {
        SceneManager.LoadScene("Level");
    }
    
    public void LoadGameOver() {
        SceneManager.LoadScene("Game Over");
    }

    public void QuitGame() {
        // TODO
    }

    public void LoadMainMenu() {
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
}
