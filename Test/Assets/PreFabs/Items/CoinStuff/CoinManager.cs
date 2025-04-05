using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public int coinCount = 0;
    public TextMeshProUGUI coinText;

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
