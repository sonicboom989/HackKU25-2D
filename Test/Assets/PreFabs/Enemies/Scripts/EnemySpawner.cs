using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject enemyToSpawn;
    public float spawnDelay = 3f;
    public float minDistanceFromPlayer = 3f;

    [Header("Tilemap")]
    public Tilemap groundTilemap;  // Assign this in Inspector

    private BoundsInt mapBounds;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        // Automatically get the bounds of the tilemap
        if (groundTilemap != null)
        {
            mapBounds = groundTilemap.cellBounds;
        }

        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnDelay);
    }

    void SpawnEnemy()
    {
        if (enemyToSpawn == null || player == null || groundTilemap == null) return;

        Vector2 spawnPosition;
        int maxAttempts = 30;
        int attempts = 0;

        do
        {
            int x = Random.Range(mapBounds.xMin, mapBounds.xMax);
            int y = Random.Range(mapBounds.yMin, mapBounds.yMax);
            Vector3 worldPos = groundTilemap.CellToWorld(new Vector3Int(x, y, 0)) + new Vector3(0.5f, 0.5f, 0); // center of tile
            spawnPosition = new Vector2(worldPos.x, worldPos.y);

            attempts++;
        }
        while (Vector2.Distance(spawnPosition, player.position) < minDistanceFromPlayer && attempts < maxAttempts);

        Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);
    }
}
