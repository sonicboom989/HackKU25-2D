using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    public int maxHealth = 3;
    int currentHealth;

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
        Instantiate(coinPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
