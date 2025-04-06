using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    public float delayBeforeReturn = 5.0f; // Match your animation length

    void Start()
    {
        Invoke("ReturnToMenu", delayBeforeReturn);
    }

    void ReturnToMenu()
    {
        SceneManager.LoadScene("Game Menu"); // Replace with exact scene name
    }
}
