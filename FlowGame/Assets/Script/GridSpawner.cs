using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridSpawner : MonoBehaviour
{
    [SerializeField]
    private Vector2 GridSize;

    [SerializeField]
    private bool spawnOnStart;

    [SerializeField]
    private Transform gridSpawnStart;

    [SerializeField]
    private Tile spriteToSpawn;

    [SerializeField]
    private Vector2 gridOffset;

    [SerializeField]
    private Tilemap bgTilemap;

    // Start is called before the first frame update
    void Start()
    {
        if (spawnOnStart)
            CreateGrid();
    }

    private void CreateGrid()
    {
        for (int y = 0; y < GridSize.y; y++)
        {
            for (int x = 0; x < GridSize.x; x++)
            {
                Vector3Int spawnPosition = new Vector3Int((int) (gridSpawnStart.position.x + gridOffset.x * x), (int) (gridSpawnStart.position.y + -gridOffset.y * y), 1);
                Debug.Log(spawnPosition);
                bgTilemap.SetTile(spawnPosition, spriteToSpawn);
            }
        }
    }
}
