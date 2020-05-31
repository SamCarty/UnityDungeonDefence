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
    [SerializeField] GameObject[] attackers;

    Animator animator;
    bool shouldSpawn = true;
    bool isSpawning;

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
        if (isSpawning || !animator || attackers.Length == 0) yield break;
        isSpawning = true;
        animator.ResetTrigger("ClosePortal");
        animator.SetTrigger("OpenPortal");
        yield return new WaitForSeconds(portalOpenDelay);

        InstantiateRandomAttacker();
        
        yield return new WaitForSeconds(portalCloseDelay);
        animator.ResetTrigger("OpenPortal");
        animator.SetTrigger("ClosePortal");
        isSpawning = false;
    }

    void InstantiateRandomAttacker() {
        var currentTransform = transform;
        var index = Mathf.RoundToInt(Random.Range(0, attackers.Length));
        var newAttacker = Instantiate(attackers[index], currentTransform.position, currentTransform.rotation);
        newAttacker.transform.parent = transform;
    }
}
