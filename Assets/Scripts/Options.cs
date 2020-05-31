using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour {
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider difficultySlider;

    const float DEFAULT_VOLUME = 0.6f;
    const float DEFAULT_DIFFICULTY = 5f;
    
    AudioPlayer audioPlayer;

    void Start() {
        audioPlayer = FindObjectOfType<AudioPlayer>();
        volumeSlider.value = Prefs.GetMasterVolume();
        difficultySlider.value = Prefs.GetDifficulty();
    }

    void Update() {
        if (audioPlayer) {
            audioPlayer.SetVolume(volumeSlider.value);
        }
    }

    public void SaveSettings() {
        Prefs.SetMasterVolume(volumeSlider.value);
        Prefs.SetDifficulty(difficultySlider.value);
        FindObjectOfType<LevelLoaderProxy>().LoadMainMenu();
    }

    public void ResetDefaults() {
        volumeSlider.value = DEFAULT_VOLUME;
        difficultySlider.value = DEFAULT_DIFFICULTY;
    }
}
