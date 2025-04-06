using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // ✅ Use TextMeshPro

public class Level2Counter : MonoBehaviour
{
    public int totalEnemiesToKill = 25;
    private int enemiesKilled = 0;

    public TextMeshProUGUI counterText; // ✅ Use TextMeshProUGUI

    void Start()
    {
        UpdateUI();
    }

    public void EnemyDefeated()
    {
        enemiesKilled++;
        UpdateUI();

        if (enemiesKilled >= totalEnemiesToKill)
        {
            PlayerPrefs.SetString("LastLevel", "Level2");       // Track last level
            PlayerPrefs.SetString("FromGameplay", "true");      // ✅ Set gameplay flag
            SceneManager.LoadScene("ShopAndLegs");
        }
    }

    void UpdateUI()
    {
        if (counterText != null)
        {
            counterText.text = $"{enemiesKilled}/{totalEnemiesToKill} Defeated";
        }
    }
}
