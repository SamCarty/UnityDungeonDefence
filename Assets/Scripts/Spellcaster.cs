using UnityEngine;

public class Spellcaster : MonoBehaviour {
    const string PROJECTILE_PARENT_NAME = "Projectiles";
    
    [SerializeField] GameObject projectile, spellSpawnPoint;

    GameObject projectileParent;
    AttackerSpawner attackerSpawner;
    Animator animator;

    void Start() {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        CreateProjectileParent();
    }

    void CreateProjectileParent() {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent) {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
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
        var newProjectile = Instantiate(projectile, spellSpawnPoint.transform.position, transform.rotation);
        newProjectile.transform.parent = projectileParent.transform;
    }    
}
