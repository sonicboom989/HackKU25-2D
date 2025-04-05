using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public int coinCount = 0; // Starting coins
    public TextMeshProUGUI coinText; // UI text displaying coins

    void Start()
    {
        UpdateCoinUI();
    }

    public void AddCoins(int amount)
    {
        coinCount += amount;
        UpdateCoinUI();
    }

    void UpdateCoinUI()
    {
        coinText.text = "Coins: " + coinCount;
    }
}
