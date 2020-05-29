using System.Collections;
using UnityEngine;

public class Hurtable : MonoBehaviour {
    [SerializeField] int health = 100;
    [SerializeField] GameObject deathEffect;

    public void Hurt(int damage) {
        health -= damage;
        if (health <= 0) {
            TriggerDeathEffect();
            Destroy(gameObject);
        }
    }
    
    void TriggerDeathEffect() {
        var effect = Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(effect, 1f);
    }
}
