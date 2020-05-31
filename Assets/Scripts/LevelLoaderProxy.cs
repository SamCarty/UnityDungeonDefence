using UnityEngine;

public class LevelLoaderProxy : MonoBehaviour
{
    public void ReloadCurrentLevel() {
        LevelLoader.instance.ReloadCurrentLevel();
    }
    
    public void LoadLevel(int levelNum) {
        LevelLoader.instance.LoadLevel(levelNum);
    }
    
    public void LoadNextLevel() {
        LevelLoader.instance.LoadNextLevel();
    }
    
    public void LoadGameOver() {
        LevelLoader.instance.LoadGameOver();
    }

    public void QuitGame() {
        LevelLoader.instance.QuitGame();
    }

    public void LoadMainMenu() {
        LevelLoader.instance.LoadMainMenu();
    }

    public void LoadOptions() {
        LevelLoader.instance.LoadOptions();
    }

    void LoadMainMenuWithDelay() {
        LevelLoader.instance.LoadMainMenuWithDelay();
    }

}
