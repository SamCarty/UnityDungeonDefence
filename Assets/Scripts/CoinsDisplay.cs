using TMPro;
using UnityEngine;

public class CoinsDisplay : MonoBehaviour {
    [SerializeField] int coins = 400;
    TextMeshProUGUI coinsText;

    void Start() {
        coinsText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    private void UpdateDisplay() {
        coinsText.text = coins.ToString();
    }

    public void AddCoins(int amount) {
        coins += amount;
        UpdateDisplay();
    }

    public void RemoveCoins(int amount) {
        coins -= amount;
        UpdateDisplay();
    }

    public bool CanAfford(int amount) {
        return coins - amount >= 0;
    }
}
