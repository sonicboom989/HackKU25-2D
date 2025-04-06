using UnityEngine;
using UnityEngine.SceneManagement;

public class TreadmillHealth : MonoBehaviour
{
    public int maxHealth = 10;
    private int currentHealth;

    public float deathAnimLength = 1.0f;
    private Animator animator;
    private bool isDying = false;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        if (isDying) return;

        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDying = true;

        // Disable AI and collisions
        EnemyAI ai = GetComponent<EnemyAI>();
        if (ai != null) ai.enabled = false;

        Collider2D col = GetComponent<Collider2D>();
        if (col != null) col.enabled = false;

        PlayerPrefs.SetString("LastLevel", "Level3"); // ✅ Save progress
        SceneManager.LoadScene(9);         // Or whatever your end scene is


        // Play death animation
        if (animator != null)
        {
            animator.SetTrigger("Die");
        }

        // Notify BossManager that boss is defeated
        BossManager bossManager = FindFirstObjectByType<BossManager>();
        if (bossManager != null)
        {
            bossManager.OnBossDefeated();
        }

        // Destroy after animation
        Destroy(gameObject, deathAnimLength);
    }
}
