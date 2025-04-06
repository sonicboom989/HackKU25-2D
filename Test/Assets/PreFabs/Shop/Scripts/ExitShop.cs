using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitShop : MonoBehaviour
{
    private string nextScene;

    void Start()
    {
        string lastScene = PlayerPrefs.GetString("LastLevel", "Level1");
        string fromGameplay = PlayerPrefs.GetString("FromGameplay", "false");

        if (fromGameplay == "true")
        {
            if (lastScene == "Level1")
            {
                nextScene = "Level1";
                PlayerPrefs.SetString("LastShop", "Game Menu");
            }
            else if (lastScene == "level2")
            {
                nextScene = "level2";
                PlayerPrefs.SetString("LastShop", "ShopAndPull");
            }
            else
            {
                nextScene = "level3";
                PlayerPrefs.SetString("LastShop", "ShopAndLegs");
            }

            PlayerPrefs.SetString("FromGameplay", "false"); // ✅ Reset the flag after use
        }
        else
        {
            // If player entered the shop manually (not from gameplay), go back to default
            nextScene = "Level1"; // Or "MainMenu" if you prefer
        }

        PlayerPrefs.Save();
    }

    public void OnExitPressed()
    {
        SceneManager.LoadScene(nextScene);
    }
}
