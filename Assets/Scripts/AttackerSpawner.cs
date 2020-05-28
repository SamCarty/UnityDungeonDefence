using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AttackerSpawner : MonoBehaviour {

    [Header("Spawn Delay")]
    [SerializeField] float minimumSpawnDelay = 1f;

    [SerializeField] float maximumSpawnDelay = 5f;

    [SerializeField] float portalOpenDelay = 2f;
    [SerializeField] float portalCloseDelay = 1f;
    
    [Header("Attackers")]
    [SerializeField] List<GameObject> attackers;

    Animator animator;
    bool shouldSpawn = true;

    bool isSpawning = false;

    void Start() {
        animator = GetComponentInChildren<Animator>();
        StartCoroutine(SpawnWave());
    }
    
    IEnumerator SpawnWave() {
        while (shouldSpawn) {
            yield return new WaitForSeconds(Random.Range(minimumSpawnDelay, maximumSpawnDelay)); 
            StartCoroutine(SpawnAttacker());
        }
    }

    IEnumerator SpawnAttacker() {
        if (isSpawning) yield break;
        isSpawning = true;
        animator.ResetTrigger("ClosePortal");
        animator.SetTrigger("OpenPortal");
        yield return new WaitForSeconds(portalOpenDelay);

        var currentTransform = transform;
        Instantiate(attackers[0], currentTransform.position, currentTransform.rotation);
        yield return new WaitForSeconds(portalCloseDelay);

        animator.ResetTrigger("OpenPortal");
        animator.SetTrigger("ClosePortal");
        isSpawning = false;
    }
}
