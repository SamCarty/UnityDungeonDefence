using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {
    [Tooltip("Base number of seconds the game should last for (will be adjusted by the difficulty level)")]
    [SerializeField] float gameTime = 10f;

    Slider slider;
    LevelController levelController;
    bool timeUp;

    void Start() {
        slider = GetComponent<Slider>();
        levelController = FindObjectOfType<LevelController>();
        gameTime *= Prefs.GetDifficulty();
    }

    void Update() {
        if (timeUp) return;
        slider.value = Time.timeSinceLevelLoad / gameTime;

        timeUp = Time.timeSinceLevelLoad >= gameTime;
        if (timeUp) {
            if (!levelController) return;
            levelController.LevelOver();
        }
    }
}
