using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTransition : MonoBehaviour
{
    public float delay = 5.0f; // Set to your death animation length
    private bool hasTransitioned = false;

    void Start()
    {
        if (!hasTransitioned)
        {
            hasTransitioned = true;
            Invoke(nameof(GoToLastShop), delay);
        }
    }

    void GoToLastShop()
    {
        string lastLevel = PlayerPrefs.GetString("LastLevel", "Level1");

        // Level 1 death → back to main menu
        if (lastLevel == "Level1")
        {
            SceneManager.LoadScene("Game Menu");
            return;
        }

        // Otherwise continue as normal
        PlayerPrefs.SetString("FromGameplay", "true");

        switch (lastLevel)
        {
            case "level2":
                PlayerPrefs.SetString("LastShop", "ShopAndPull");
                SceneManager.LoadScene("ShopAndPull");
                break;
            default:
                PlayerPrefs.SetString("LastShop", "ShopAndLegs");
                SceneManager.LoadScene("ShopAndLegs");
                break;
        }

        PlayerPrefs.Save();
    }

}
