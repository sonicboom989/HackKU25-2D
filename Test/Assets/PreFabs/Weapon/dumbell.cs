using UnityEngine;

public class Dumbbell : MonoBehaviour
{
    public float lifetime = 3f;
    public int damage = 1;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyAI enemy = collision.gameObject.GetComponent<EnemyAI>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }

        // Destroy dumbbell on any collision
        Destroy(gameObject);
    }
}
