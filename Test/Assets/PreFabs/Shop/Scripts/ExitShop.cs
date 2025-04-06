using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitShop : MonoBehaviour
{
    public void OnExitPressed()
    {
        // Get the current active scene at the moment the exit button is pressed.
        string currentScene = SceneManager.GetActiveScene().name;

        // Check for specific shop scenes.
        if (currentScene == "ShopAndPull")
        {
            SceneManager.LoadScene("level2");
        }
        else if (currentScene == "ShopAndLegs")
        {
            SceneManager.LoadScene("level3");
        }
        else if (currentScene == "Game Menu")
        {
            SceneManager.LoadScene("Level1");
        }
        else
        {
            // Fallback logic using PlayerPrefs.
            string lastScene = PlayerPrefs.GetString("LastLevel", "level1");
            string fromGameplay = PlayerPrefs.GetString("FromGameplay", "false");
            string nextLevel = PlayerPrefs.GetString("NextLevel", "level1");

            string nextScene;
            if (fromGameplay == "true")
            {
                nextScene = nextLevel;
                PlayerPrefs.SetString("FromGameplay", "false");
            }
            else
            {
                // Return to the same level if the shop was entered manually.
                nextScene = lastScene;
            }

            PlayerPrefs.Save();
            SceneManager.LoadScene(nextScene);
        }
    }
}
