using UnityEngine;

public class Attacker : MonoBehaviour {
    
    float movementSpeed = 1f;
    GameObject attackTarget;
    Animator animator;

    void Awake() {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    void OnDestroy() {
        FindObjectOfType<LevelController>().AttackerDestroyed();
    }

    void Start() {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.Translate(Vector2.left * (movementSpeed * Time.deltaTime));
    }

    public void SetMovementSpeed(float speed) {
        movementSpeed = speed;
    }

    public void Attack(GameObject target) {
        if (!animator) return;
        attackTarget = target;
        animator.SetBool("Attack", true);
    }
    
    public void StopAttack() {
        if (!animator) return;
        attackTarget = null;
        animator.SetBool("Attack", false);
    }

    public void HitTarget(int damage) {
        if (!attackTarget) return;
        Hurtable targetHurtable = attackTarget.GetComponent<Hurtable>();
        if (targetHurtable) {
            targetHurtable.Hurt(damage);
        }
    }

    public void Jump() {
        animator.SetTrigger("JumpTrigger");
    }
}
