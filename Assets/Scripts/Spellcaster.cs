using UnityEngine;

public class Spellcaster : MonoBehaviour {
    [SerializeField] GameObject projectile, spellSpawnPoint;

    AttackerSpawner attackerSpawner;
    Animator animator;

    void Start() {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }

    void Update() {
        animator.SetBool("Attack", AttackerInLane());
    }

    private void SetLaneSpawner() {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (var spawner in spawners) {
            if (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon) {
                attackerSpawner = spawner;
            }
        }
    }

    bool AttackerInLane() {
        return attackerSpawner.transform.childCount > 1;
    }
    
    public void Cast() {
        Instantiate(projectile, spellSpawnPoint.transform.position, transform.rotation);
    }    
}
