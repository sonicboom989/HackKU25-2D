using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int coinValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Coin touched by: " + other.gameObject.name);
        if(other.CompareTag("Player"))
        {
            FindObjectOfType<CoinManager>().AddCoins(coinValue);
            Destroy(gameObject);
        }
    }

}
