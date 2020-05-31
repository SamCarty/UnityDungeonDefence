using UnityEngine;

public class LevelLoaderProxy : MonoBehaviour
{
    public void LoadLevel() {
        LevelLoader.instance.LoadLevel();
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

    void LoadMainMenuWithDelay() {
        LevelLoader.instance.LoadMainMenuWithDelay();
    }

}
