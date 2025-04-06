using UnityEngine;
using UnityEngine.SceneManagement;

public class BossManager : MonoBehaviour
{
    public void OnBossDefeated()
    {
        SceneManager.LoadScene(9);
    }
}
