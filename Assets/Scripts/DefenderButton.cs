using UnityEngine;

public class DefenderButton : MonoBehaviour {
    [SerializeField] Defender defenderPrefab;
    
    void OnMouseUp() {
        HighlightClickedButton();
        FindObjectOfType<DefenderSpawner>().SetDefender(defenderPrefab);
    }

    void HighlightClickedButton() {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach (var button in buttons) {
            button.GetComponent<SpriteRenderer>().color = new Color32(41, 41, 41, 255);
        }
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
