using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;

    public GameObject coinPrefab; // prefab of coin dropped
    public int coinAmount = 1; // coins dropped when dead

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Instantiate coin at monster position
        Instantiate(coinPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
