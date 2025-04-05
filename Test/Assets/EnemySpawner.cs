using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;   // Assign in Inspector
    public float spawnInterval = 3f; // Spawn every 3 seconds
    public float spawnRadius = 5f;   // How far from the spawner enemies appear

    void Start()
    {
        // Start repeating spawn
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        // Choose a random point in a circle around the spawner
        Vector2 spawnOffset = Random.insideUnitCircle * spawnRadius;
        Vector2 spawnPosition = (Vector2)transform.position + spawnOffset;

        // Create the enemy
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
