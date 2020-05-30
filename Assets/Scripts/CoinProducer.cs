using UnityEngine;

public class CoinProducer : MonoBehaviour
{
    [SerializeField] int coinsAmount = 50;
    
    void GenerateCoins() {
        FindObjectOfType<CoinsDisplay>().AddCoins(coinsAmount);
    }
}
