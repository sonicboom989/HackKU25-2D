using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level2EnemyCounter : MonoBehaviour
{
    public int totalEnemiesToKill = 25;
    private int enemiesKilled = 0;

    public Text counterText; // Assign your UI text in the Inspector

    void Start()
    {
        UpdateUI();
    }

    public void OnEnemyKilled()
    {
        enemiesKilled++;
        UpdateUI();

        if (enemiesKilled >= totalEnemiesToKill)
        {
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
