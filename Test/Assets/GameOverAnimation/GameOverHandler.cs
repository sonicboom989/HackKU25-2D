using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTransition : MonoBehaviour
{
    public float delay = 5.0f; // Duration of your death animation
    private bool hasTransitioned = false;

    void Start()
    {
        if (!hasTransitioned)
        {
            hasTransitioned = true;
            Invoke(nameof(GoToShopBasedOnPreviousLevel), delay);
        }
    }

    void GoToShopBasedOnPreviousLevel()
    {
        // IMPORTANT: Ensure that the "PreviousLevel" value is set in your gameplay scene,
        // before you load the GameOver scene. For example, in your gameplay script, do:
        //
        //   string currentLevel = SceneManager.GetActiveScene().name;
        //   PlayerPrefs.SetString("PreviousLevel", currentLevel);
        //   PlayerPrefs.Save();
        //   SceneManager.LoadScene("GameOver");
        //
        // This ensures that "PreviousLevel" contains the gameplay scene's name, not "GameOver".

        // Retrieve the stored previous level.
        // Default to "Level1" if no value was saved.
        string previousLevel = PlayerPrefs.GetString("PreviousLevel", "Level1");

        // Debug log to output the retrieved previousLevel.
        Debug.Log("GameOverTransition: PreviousLevel retrieved: " + previousLevel);

        // Check for an invalid value. If previousLevel is "GameOver", then something went wrong.
        if (previousLevel == "GameOver")
        {
            Debug.LogWarning("GameOverTransition: PreviousLevel is 'GameOver', which is invalid. " +
                             "Make sure you set PreviousLevel in your gameplay scene before loading GameOver.");
            SceneManager.LoadScene("Game Menu");
            return;
        }

        // Use the case-sensitive scene names to load the correct shop.
        if (previousLevel == "level2")
        {
            Debug.Log("GameOverTransition: Loading ShopAndPull since PreviousLevel is level2");
            SceneManager.LoadScene("ShopAndPull");
        }
        else if (previousLevel == "level3")
        {
            Debug.Log("GameOverTransition: Loading ShopAndLegs since PreviousLevel is level3");
            SceneManager.LoadScene("ShopAndLegs");
        }
        else if (previousLevel == "Level1")
        {
            Debug.Log("GameOverTransition: Loading Shop for Level1");
            SceneManager.LoadScene("Shop");
        }
        else
        {
            Debug.Log("GameOverTransition: Unknown PreviousLevel. Loading Game Menu as fallback.");
            SceneManager.LoadScene("Game Menu");
        }
    }
}
