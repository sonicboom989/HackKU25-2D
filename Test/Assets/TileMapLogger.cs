using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapLogger : MonoBehaviour
{
    void Start()
    {
        Tilemap tilemap = GetComponent<Tilemap>();
        if (tilemap != null)
        {
            BoundsInt bounds = tilemap.cellBounds;
            Vector3 min = tilemap.CellToWorld(bounds.min);
            Vector3 max = tilemap.CellToWorld(bounds.max);

            Debug.Log($"Tilemap Bounds:\nMin: {min}\nMax: {max}");
        }
    }
}
