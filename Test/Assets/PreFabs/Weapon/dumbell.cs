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
            Debug.Log("Dumbbell collided with: " + collision.gameObject.name);
            MonsterHealth health = collision.gameObject.GetComponent<MonsterHealth>();
            if (health != null)
            {
                health.TakeDamage(1);
            }
        }

        // Destroy dumbbell on any collision
        Destroy(gameObject);
    }
}
