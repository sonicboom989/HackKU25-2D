using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject enemyToSpawn;        // Drag your enemy prefab here
    public float spawnDelay = 3f;          // Delay between spawns (seconds)
    public float enemySpawnRadius = 5f;    // Distance from the spawner

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnDelay);
    }

    void SpawnEnemy()
    {
        // Pick a random point in a circle around the spawner
        Vector2 spawnOffset = Random.insideUnitCircle * enemySpawnRadius;
        Vector2 spawnPosition = (Vector2)transform.position + spawnOffset;

        // Create the enemy
        Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);
    }
}
