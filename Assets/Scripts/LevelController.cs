using System.Collections;
using UnityEngine;

public class LevelController : MonoBehaviour {

    [SerializeField] GameObject levelCompleteCanvas;
    [SerializeField] GameObject levelGameOverCanvas;
    
    bool levelOver;
    int totalAttackers;

    void Start() {
        levelCompleteCanvas.SetActive(false);
        levelGameOverCanvas.SetActive(false);
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
        
        if (!levelOver) return; 
        
        // if there are no attackers level, end the level
        if (totalAttackers <= 0) {
            StartCoroutine(HandleWin());
        }
    }

    IEnumerator HandleWin() {
        levelCompleteCanvas.SetActive(true);
        FindObjectOfType<AudioPlayer>().PlayVictorySound();
        yield return new WaitForSeconds(2);
        FindObjectOfType<LevelLoaderProxy>().LoadNextLevel();
    }
    
    public void GameOver() {
        StartCoroutine(HandleLoss());
    }
    
    IEnumerator HandleLoss() {
        Time.timeScale = 0f;
        levelGameOverCanvas.SetActive(true);
        FindObjectOfType<AudioPlayer>().PlayFailureSound();
        yield return new WaitForSeconds(2);
    }
}
