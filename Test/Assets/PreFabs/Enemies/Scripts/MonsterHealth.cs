using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public GameObject coinPrefab;
    public int coinAmount = 1;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"{gameObject.name} took {damage} damage. Current health: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log($"{gameObject.name} died. Dropping {coinAmount} coin(s).");

        // Drop coins with a small random offset
        for (int i = 0; i < coinAmount; i++)
        {
            Vector3 spawnPos = transform.position + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0);
            Instantiate(coinPrefab, spawnPos, Quaternion.identity);
        }

        // Instead of destroying the enemy, deactivate it.
        gameObject.SetActive(false);
    }
}
