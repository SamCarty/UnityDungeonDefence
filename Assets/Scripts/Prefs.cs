using UnityEngine;

public class Prefs : MonoBehaviour {
    const string MASTER_VOLUME = "MASTER_VOLUME";
    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;
    
    const string DIFFICULTY = "DIFFICULTY";
    const float MIN_DIFFICULTY = 1f;
    const float MAX_DIFFICULTY = 10f;
    
    public static float GetMasterVolume() {
        return PlayerPrefs.GetFloat(MASTER_VOLUME);
    }

    public static void SetMasterVolume(float masterVolume) {
        if (masterVolume >= MIN_VOLUME && masterVolume <= MAX_VOLUME) {
            Debug.Log("Master volume set to " + masterVolume);
            PlayerPrefs.SetFloat(MASTER_VOLUME, masterVolume);
        }
        else {
            Debug.LogError("Master volume not in range.");
        }
    }

    public static float GetDifficulty() {
        return PlayerPrefs.GetFloat(DIFFICULTY);
    }

    public static void SetDifficulty(float difficulty) {
        PlayerPrefs.SetFloat(DIFFICULTY, difficulty);
    }
    
}