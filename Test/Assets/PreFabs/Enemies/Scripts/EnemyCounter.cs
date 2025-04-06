using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EnemyCounter : MonoBehaviour
{
    public int totalEnemiesToKill = 36;
    private int enemiesKilled = 0;

    public TextMeshProUGUI counterText; // 👈 TMP support

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
            PlayerPrefs.SetString("LastLevel", "Level1");
            PlayerPrefs.SetString("FromGameplay", "true"); // ✅ Add this
            SceneManager.LoadScene("ShopAndPull");
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
