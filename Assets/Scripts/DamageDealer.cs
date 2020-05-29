using UnityEngine;

public class DamageDealer : MonoBehaviour {
    [SerializeField] int damage = 50;

    void OnTriggerEnter2D(Collider2D other) {
        Hurtable hurtable = other.GetComponent<Hurtable>();
        Attacker attacker = other.GetComponent<Attacker>();
        if (!attacker || !hurtable) return;
        DealDamage(hurtable);
    }

    void DealDamage(Hurtable hurtable) {
        hurtable.Hurt(damage);
    }
}
