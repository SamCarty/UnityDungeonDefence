using System.Collections;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision) {
        StartCoroutine(DestroyObject(collision.gameObject));
    }

    IEnumerator DestroyObject(GameObject obj) {
        yield return new WaitForSeconds(2);
        Destroy(obj);
    }
}
