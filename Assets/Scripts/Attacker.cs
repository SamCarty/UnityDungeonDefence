﻿using UnityEngine;

public class Attacker : MonoBehaviour {
    
    [Range(0, 10)]
    [SerializeField]
    float movementSpeed = 1f;

    void Update()
    {
        transform.Translate(Vector2.left * (movementSpeed * Time.deltaTime));
    }

    public void SetMovementSpeed(float speed) {
        movementSpeed = speed;
    }
}
