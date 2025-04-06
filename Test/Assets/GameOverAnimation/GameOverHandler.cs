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
            Invoke(nameof(GoToMenu), delay);
        }
    }

    void GoToMenu()
    {
        SceneManager.LoadScene("Game Menu"); // 🔁 Replace with your actual shop screen name
    }
}
