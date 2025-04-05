using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public void LoadLevel1()
    {
        SceneManager.LoadScene(2);
    }

    // You can add a method for Shop later
}
