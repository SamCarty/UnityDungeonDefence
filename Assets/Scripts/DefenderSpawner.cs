using UnityEngine;

public class DefenderSpawner : MonoBehaviour {
    Defender defender;

    void OnMouseUp() {
        SpawnDefender();
    }

    public void SetDefender(Defender newDefender) {
        defender = newDefender;
    }

    void SpawnDefender() {
        if (!defender) return;
        
        CoinsDisplay coinsDisplay = FindObjectOfType<CoinsDisplay>();
        if (!coinsDisplay) return;
        
        if (coinsDisplay.CanAfford(defender.GetCost())) {
            coinsDisplay.RemoveCoins(defender.GetCost());
            var position = GetMouseWorldPosition();
            var defenderObject = Instantiate(defender, position, Quaternion.identity);
            SetSortingOrderByRowNumber(defenderObject, position);
        }
    }
    
    Vector2 GetMouseWorldPosition() {
        if (Camera.main == null) return new Vector2();
        var worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return worldPosition.Round(0);
    }

    void SetSortingOrderByRowNumber(Defender defenderObject, Vector2 position) {
        var numRows = transform.localScale.y;
        defenderObject.GetComponentInChildren<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(numRows) - Mathf.RoundToInt(position.y);
    }
}
