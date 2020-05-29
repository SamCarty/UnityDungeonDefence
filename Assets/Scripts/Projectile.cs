using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Range(0, 10)]
    [SerializeField]
    float movementSpeed = 1f;

    Animator animator;
    bool hasHit;

    void Start() {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!hasHit) transform.Translate(Vector2.right * (movementSpeed * Time.deltaTime));
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        Hurtable hurtable = other.GetComponent<Hurtable>();
        Attacker attacker = other.GetComponent<Attacker>();
        if (!attacker || !hurtable) return;
        hasHit = true;
        if (animator) animator.SetTrigger("Destroy");
        Destroy(gameObject, 1f);
    }
}
