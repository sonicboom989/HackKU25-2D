using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public void LoadLevel1()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadLevel2()
    { SceneManager.LoadScene(4);}

    // You can add a method for Shop later
}