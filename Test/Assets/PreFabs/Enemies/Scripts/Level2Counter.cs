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
            PlayerPrefs.SetString("LastLevel", "Level2");
            PlayerPrefs.SetString("FromGameplay", "true");
            PlayerPrefs.SetString("NextLevel", "level3"); // ✅ SET IT HERE
            PlayerPrefs.Save();
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
