using UnityEngine;

public class AudioPlayer : MonoBehaviour {
    [SerializeField] AudioClip menuLoadedSound;

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
        }
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
