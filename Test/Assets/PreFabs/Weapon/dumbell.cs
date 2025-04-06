using UnityEngine;

public class Dumbbell : MonoBehaviour
{
    public float lifetime = 3f;
    public int baseDamage = 1;
    public float speed = 10f;
    public Vector3 spawnOffset = new Vector3(0, 0.5f, 0);

    private Rigidbody2D rb;
    private float finalDamage;

    public AudioClip throwSound;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position += spawnOffset;

        // Apply strength upgrade if unlocked
        finalDamage = baseDamage;
        if (PlayerPrefs.GetInt("StrengthUpgraded", 0) == 1)
        {
            finalDamage += 0.5f; // Add 0.5 damage
        }

        // 🔊 Play sound
        audioSource = GetComponent<AudioSource>();
        if (throwSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(throwSound);
        }

        Collider2D myCol = GetComponent<Collider2D>();

        // Ignore player, coins, other dumbbells
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Collider2D playerCol = player.GetComponent<Collider2D>();
            if (playerCol != null && myCol != null)
            {
                Physics2D.IgnoreCollision(myCol, playerCol);
            }
        }

        foreach (GameObject coin in GameObject.FindGameObjectsWithTag("Coin"))
        {
            Collider2D coinCol = coin.GetComponent<Collider2D>();
            if (coinCol != null && myCol != null)
            {
                Physics2D.IgnoreCollision(myCol, coinCol);
            }
        }

        foreach (GameObject db in GameObject.FindGameObjectsWithTag("Dumbbell"))
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

        // Move
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - (Vector2)transform.position).normalized;
        rb.linearVelocity = direction * speed;

        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            int roundedDamage = Mathf.RoundToInt(finalDamage); // ✅ Convert float to int safely

            // Level 1
            MonsterHealth health1 = other.GetComponent<MonsterHealth>();
            if (health1 != null)
            {
                health1.TakeDamage(roundedDamage);
                Destroy(gameObject);
                return;
            }

            // Level 2
            Level2MonsterHealth health2 = other.GetComponent<Level2MonsterHealth>();
            if (health2 != null)
            {
                health2.TakeDamage(roundedDamage);
                Destroy(gameObject);
                return;
            }

            // Boss
            TreadmillHealth bossHealth = other.GetComponent<TreadmillHealth>();
            if (bossHealth != null)
            {
                bossHealth.TakeDamage(roundedDamage);
                Destroy(gameObject);
                return;
            }
        }

        if (!other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
