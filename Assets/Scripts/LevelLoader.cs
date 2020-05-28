using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
    
    [SerializeField] float splashScreenDelay = 3f;

    AudioPlayer audioPlayer;

    void Awake() {
        SetupSingleton();
    }

    void SetupSingleton() {
        if (FindObjectsOfType(GetType()).Length > 1) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
            audioPlayer = FindObjectOfType<AudioPlayer>();
        }
    }
    
    void Start() {
        if (SceneManager.GetActiveScene().name == "Splash") LoadMainMenu();
    }

    public void LoadSplash() {
        SceneManager.LoadScene("Splash");
    }

    public void LoadMainMenu() {
        StartCoroutine(LoadMainMenuWithDelay());
    }

    public void LoadLevel() {
        // TODO
        SceneManager.LoadScene("Level");
    }

    public void QuitGame() {
        // TODO
    }

    IEnumerator LoadMainMenuWithDelay() {
        yield return new WaitForSeconds(splashScreenDelay);
        SceneManager.LoadScene("Menu");
        audioPlayer.PlayMenuLoadedSound();
    }
}
