using UnityEngine;

public class Dumbbell : MonoBehaviour
{
    public float lifetime = 3f;
    public int damage = 1;
    public float speed = 10f;
    public Vector3 spawnOffset = new Vector3(0, 0.5f, 0); // Adjust offset as needed

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Move the dumbbell by the offset to avoid immediate collision with the player.
        transform.position += spawnOffset;

        // Ignore collisions with the player.
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Collider2D playerCollider = player.GetComponent<Collider2D>();
            Collider2D dumbbellCollider = GetComponent<Collider2D>();
            if (playerCollider != null && dumbbellCollider != null)
            {
                Physics2D.IgnoreCollision(playerCollider, dumbbellCollider);
            }
        }

        // Calculate direction toward the mouse cursor.
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - (Vector2)transform.position).normalized;
        rb.linearVelocity = direction * speed;

        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger hit: " + other.name);

        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy hit by dumbbell!");

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

            Destroy(gameObject, 0.01f);
        }
    }
}
