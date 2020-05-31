using UnityEngine;

public class Treasure : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<Attacker>()) {
            FindObjectOfType<TreasureHealth>().Hurt();
        }
    }
}
