using UnityEngine;

public class Dumbbell : MonoBehaviour
{
    public float lifetime = 3f;
    public int damage = 1;

    void Start()
    {
        Destroy(gameObject, lifetime); // Auto-destroy after time
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger hit: " + other.name); // Confirm this is working

        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy hit by dumbbell!"); // Confirm tag detection

            MonsterHealth health = other.GetComponent<MonsterHealth>();
            if (health != null)
            {
                Debug.Log("Enemy has MonsterHealth! Dealing damage...");
                health.TakeDamage(damage);
            }
            else
            {
                Debug.LogWarning("Enemy is missing MonsterHealth script!");
            }
        }

        Destroy(gameObject);
    }
}
