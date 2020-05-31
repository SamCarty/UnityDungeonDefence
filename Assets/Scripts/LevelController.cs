using System;
using UnityEngine;

public class LevelController : MonoBehaviour {

    [SerializeField] GameObject levelCompleteCanvas;
    
    bool levelOver;
    int totalAttackers;

    void Start() {
        levelCompleteCanvas.SetActive(false);
    }

    void Update() {
        if (!levelOver) return;
        // if there are no attackers level, end the level
        if (totalAttackers == 0) {
            levelCompleteCanvas.SetActive(true);
        }
    }
    
    public void LevelOver() {
        levelOver = true;
        foreach (var spawner in FindObjectsOfType<AttackerSpawner>()) {
            // tell each spawner to stop spawning
            spawner.Stop();
        }
    }

    public void AttackerSpawned() {
        totalAttackers++;
    }

    public void AttackerDestroyed() {
        totalAttackers--;
    }
}
