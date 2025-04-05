using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour
{
    public int coinValue = 1;
    public float pickupDelay = 0.25f; // Delay (in seconds) before the coin can be picked up
    private bool canPickup = false;
    private Collider2D coinCollider;

    void Start()
    {
        coinCollider = GetComponent<Collider2D>();
        // Disable the collider initially so it doesn't trigger immediately
        coinCollider.enabled = false;
        StartCoroutine(EnablePickupAfterDelay(pickupDelay));
    }

    IEnumerator EnablePickupAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canPickup = true;
        coinCollider.enabled = true; // Re-enable collider so the coin can be picked up
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Only allow pickup if the coin is ready and the player collides
        if (canPickup && other.CompareTag("Player"))
        {
            CoinManager coinManager = FindFirstObjectByType<CoinManager>();
            if (coinManager != null)
            {
                coinManager.AddCoins(coinValue);
            }
            Destroy(gameObject);
        }
    }
}
