using UnityEngine;

public class DefenderSpawner : MonoBehaviour {
    [SerializeField] GameObject wizard;

    void OnMouseUp() {
        
        Instantiate(wizard, GetMouseWorldPosition(), Quaternion.identity);
    }

    Vector2 GetMouseWorldPosition() {
        if (Camera.main == null) return new Vector2();
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
