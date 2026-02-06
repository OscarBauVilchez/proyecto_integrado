using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    public Transform player;
    public GameObject tilePrefab;

    public int chunkSize = 16;
    public int viewDistance = 2;

    public int seed = 12345;
    public float noiseScale = 0.1f;

    private Dictionary<Vector2Int, GameObject> chunks =
        new Dictionary<Vector2Int, GameObject>();
    int GetGroundHeight(float worldX)
    {
        float heightNoise = Mathf.PerlinNoise(
            (worldX + seed) * 0.05f,
            seed * 0.01f
        );

        return Mathf.FloorToInt(heightNoise * 10) + 5;
    }

    Vector2Int GetChunkCoord(Vector2 position)
    {
        int x = Mathf.FloorToInt(position.x / chunkSize);
        int y = Mathf.FloorToInt(position.y / chunkSize);
        return new Vector2Int(x, y);
    }
    void GenerateChunk(Vector2Int coord)
    {
        if (chunks.ContainsKey(coord))
        { GameObject chunk = new GameObject($"Chunk {coord}");
            chunk.transform.position = new Vector3(coord.x * chunkSize,coord.y * chunkSize,0);
            for (int x = 0; x < chunkSize; x++)
            {
                for (int y = 0; y < chunkSize; y++)
                {
                    float worldX = coord.x * chunkSize + x;
                    float worldY = coord.y * chunkSize + y;

                    float noise = Mathf.PerlinNoise(
                        (worldX + seed) * noiseScale,
                        (worldY + seed) * noiseScale
                    );

                    int groundHeight = GetGroundHeight(worldX);

                    if (worldY <= groundHeight)
                    {
                        // Ground block
                    }


                }
            }

         chunks.Add(coord, chunk);

        }
        return;

        
    }
    void UnloadFarChunks(Vector2Int playerChunk)
    {
        List<Vector2Int> removeList = new List<Vector2Int>();

        foreach (var chunk in chunks)
        {
            if (Vector2Int.Distance(chunk.Key, playerChunk) > viewDistance + 1)
            {
                Destroy(chunk.Value);
                removeList.Add(chunk.Key);
            }
        }

        foreach (var coord in removeList)
            chunks.Remove(coord);
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2Int playerChunk = GetChunkCoord(player.position);

        for (int x = -viewDistance; x <= viewDistance; x++)
        {
            for (int y = -viewDistance; y <= viewDistance; y++)
            {
                Vector2Int coord = new Vector2Int(
                    playerChunk.x + x,
                    playerChunk.y + y
                );

                GenerateChunk(coord);
            }
        }

        UnloadFarChunks(playerChunk);
    }
}
