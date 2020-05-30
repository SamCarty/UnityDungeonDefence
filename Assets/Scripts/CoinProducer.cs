using UnityEngine;

public class CoinProducer : MonoBehaviour
{
    [SerializeField] int coinsAmount = 50;
    
    public void GenerateCoins() {
        FindObjectOfType<CoinsDisplay>().AddCoins(coinsAmount);
    }
}
