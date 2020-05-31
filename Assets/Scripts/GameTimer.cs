using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {
    [Tooltip("Number of seconds the game should last for")]
    [SerializeField] float gameTime = 10f;

    Slider slider;
    LevelController levelController;
    bool timeUp;

    void Start() {
        slider = GetComponent<Slider>();
        levelController = FindObjectOfType<LevelController>();
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
