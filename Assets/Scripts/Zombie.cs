using UnityEngine;

public class Zombie : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.GetComponent<Defender>()) {
            GetComponent<Attacker>().Attack(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.GetComponent<Defender>()) {
            GetComponent<Attacker>().StopAttack();
        }
    }
}
