using UnityEngine;

public class AudioPlayer : MonoBehaviour {
    [SerializeField] AudioClip menuLoadedSound;
    [SerializeField] AudioClip failureSound;
    [SerializeField] AudioClip victorySound;
    [SerializeField] AudioClip levelStartSound;
    
    AudioSource audioSource;

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
            audioSource = GetComponent<AudioSource>();
            audioSource.volume = Prefs.GetMasterVolume();
        }
    }

    public void SetVolume(float volume) {
        audioSource.volume = volume;
    }

    public void PlayFailureSound() {
        PlaySound(failureSound);
    }
    
    public void PlayVictorySound() {
        PlaySound(victorySound);
    }
    
    public void PlayLevelStartSound() {
        PlaySound(levelStartSound);
    }
    
    public void PlayMenuLoadedSound() {
        PlaySound(menuLoadedSound);
    }

    void PlaySound(AudioClip audioClip) {
        if (!audioSource) return;
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
