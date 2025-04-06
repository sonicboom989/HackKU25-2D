using UnityEngine;
using TMPro;

public class FinalSceneTimer : MonoBehaviour
{
    public float timeUntilExit = 10f; // Seconds before the game quits
    public TextMeshProUGUI timerText; // Optional: assign a TMP Text object to show countdown

    private float timer;

    void Start()
    {
        timer = timeUntilExit;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timerText != null)
        {
            timerText.text = $"Exiting in {Mathf.CeilToInt(timer)}...";
        }

        if (timer <= 0f)
        {
            QuitGame();
        }
    }

    void QuitGame()
    {
        Debug.Log("Game is quitting...");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
