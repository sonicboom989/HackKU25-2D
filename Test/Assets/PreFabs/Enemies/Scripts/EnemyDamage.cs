using UnityEngine;

public class EnemyTouchDamage : MonoBehaviour
{
    public int damageAmount = 1;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.collider.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
                Debug.Log("Enemy hit player!");
            }
        }
    }
}
