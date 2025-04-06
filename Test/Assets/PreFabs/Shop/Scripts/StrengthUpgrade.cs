using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StrengthUpgrade : MonoBehaviour
{
    public int cost = 30;
    public Button upgradeButton;
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI upgradeStatusText;

    private int playerGold;
    private bool isUpgraded = false;

    void Start()
    {
        playerGold = PlayerPrefs.GetInt("Gold", 0);
        isUpgraded = PlayerPrefs.GetInt("StrengthUpgraded", 0) == 1;

        upgradeButton.onClick.AddListener(BuyUpgrade);
        UpdateUI();
    }

    void BuyUpgrade()
    {
        if (isUpgraded)
        {
            upgradeStatusText.text = "Already Upgraded!";
            return;
        }

        if (playerGold >= cost)
        {
            playerGold -= cost;
            PlayerPrefs.SetInt("Gold", playerGold);
            PlayerPrefs.SetInt("StrengthUpgraded", 1);
            PlayerPrefs.Save();

            isUpgraded = true;
            upgradeStatusText.text = "Strength Upgraded!";
            upgradeButton.interactable = false;
            UpdateUI();
        }
        else
        {
            upgradeStatusText.text = "Not Enough Gold!";
        }
    }

    void UpdateUI()
    {
        goldText.text = "Gold: " + playerGold;

        if (isUpgraded)
        {
            upgradeStatusText.text = "Strength Upgraded!";
            upgradeButton.interactable = false;
        }
    }
}
