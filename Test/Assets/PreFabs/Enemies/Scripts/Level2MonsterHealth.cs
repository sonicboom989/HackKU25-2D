using UnityEngine;

public class Level2MonsterHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public GameObject coinPrefab;
    public int coinAmount = 1;

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

        // Play death animation
        if (animator != null)
        {
            animator.SetTrigger("Die");
        }

        // Drop coins
        if (coinPrefab != null)
        {
            for (int i = 0; i < coinAmount; i++)
            {
                Instantiate(coinPrefab, transform.position, Quaternion.identity);
            }
        }
        else
        {
            Debug.LogWarning("No coinPrefab assigned on " + gameObject.name);
        }

        // Notify the level 2 counter
        Level2Counter counter = FindFirstObjectByType<Level2Counter>();
        if (counter != null)
        {
            counter.EnemyDefeated();
        }

        // Destroy after animation
        Destroy(gameObject, deathAnimLength);
    }
}
