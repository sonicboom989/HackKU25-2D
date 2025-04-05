using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyToSpawn;         // Drag your enemy prefab here
    public float spawnDelay = 3f;           // Delay between spawns
    public float enemySpawnRadius = 5f;     // Distance from spawner

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnDelay);
    }

    void SpawnEnemy()
    {
        Vector2 spawnOffset = Random.insideUnitCircle * enemySpawnRadius;
        Vector2 spawnPosition = (Vector2)transform.position + spawnOffset;

        Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);
    }
}
