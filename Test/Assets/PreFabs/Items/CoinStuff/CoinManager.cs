using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public int coinCount = 0;
    public TextMeshProUGUI coinText;

    private static bool hasResetThisSession = false;

    void Awake()
    {
        // Only delete coins once per full game launch
        if (!hasResetThisSession)
        {
            PlayerPrefs.DeleteKey("TotalCoins");
            PlayerPrefs.Save();
            hasResetThisSession = true;
        }
    }

    void Start()
    {
        coinCount = PlayerPrefs.GetInt("TotalCoins", 0);
        UpdateCoinUI();
    }

    public void AddCoins(int amount)
    {
        coinCount += amount;
        UpdateCoinUI();

        PlayerPrefs.SetInt("TotalCoins", coinCount);
        PlayerPrefs.Save();
    }

    void UpdateCoinUI()
    {
        if (coinText != null)
            coinText.text = "Coins: " + coinCount;
    }

    public void ResetCoinsManually()
    {
        coinCount = 0;
        PlayerPrefs.SetInt("TotalCoins", 0);
        PlayerPrefs.Save();
        UpdateCoinUI();
    }
}
