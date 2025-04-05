using UnityEngine;

public class Dumbbell : MonoBehaviour
{
    public float lifetime = 3f;
    public int damage = 1;
    public float speed = 10f;
    public Vector3 spawnOffset = new Vector3(0, 0.5f, 0); // Adjust if needed

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Move the dumbbell slightly to avoid immediate collision with the player
        transform.position += spawnOffset;

        Collider2D myCol = GetComponent<Collider2D>();

        // Ignore collisions with the player
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Collider2D playerCol = player.GetComponent<Collider2D>();
            if (playerCol != null && myCol != null)
            {
                Physics2D.IgnoreCollision(myCol, playerCol);
            }
        }

        // Ignore collisions with coins
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        foreach (GameObject coin in coins)
        {
            Collider2D coinCol = coin.GetComponent<Collider2D>();
            if (coinCol != null && myCol != null)
            {
                Physics2D.IgnoreCollision(myCol, coinCol);
            }
        }

        // Ignore collisions with other dumbbells
        GameObject[] allDumbbells = GameObject.FindGameObjectsWithTag("Dumbbell");
        foreach (GameObject db in allDumbbells)
        {
            if (db != gameObject)
            {
                Collider2D otherCol = db.GetComponent<Collider2D>();
                if (otherCol != null && myCol != null)
                {
                    Physics2D.IgnoreCollision(myCol, otherCol);
                }
            }
        }

        // Move toward the mouse position
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - (Vector2)transform.position).normalized;
        rb.linearVelocity = direction * speed;

        // Auto-destroy after a few seconds
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            MonsterHealth health = other.GetComponent<MonsterHealth>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }

            Destroy(gameObject); // Destroy only after hitting an enemy
        }
    }
}
