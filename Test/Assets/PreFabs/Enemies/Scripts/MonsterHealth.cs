using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public GameObject coinPrefab;
    public int coinAmount = 1;

    public float deathAnimLength = 1.0f; // 👈 Set this to match your animation length
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
        if (ai != null)
        {
            ai.enabled = false;
        }

        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
        {
            col.enabled = false;
        }

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

        // Notify the enemy counter system
        EnemyCounter counter = FindFirstObjectByType<EnemyCounter>();
        if (counter != null)
        {
            counter.EnemyDefeated();
        }



        // Destroy the object after the animation finishes
        Destroy(gameObject, deathAnimLength);
    }
}
