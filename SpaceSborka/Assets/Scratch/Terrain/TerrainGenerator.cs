using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int mapWidth = 512;
    public int mapHeight = 512;
    public int mapScale = 20;

    public float frequency = 0.25f;
    public float amplitude = 0.1f;

    private float[,] noiseMap;

    

    void Start()
    {
        GenerateMap();
        CreateMap();
    }

    void GenerateMap()
    {
        noiseMap = new float[mapWidth, mapHeight];

        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                float xCoord = x / (float)mapWidth * mapScale * frequency;
                float yCoord = y / (float)mapHeight * mapScale * frequency;

                float perlinValue = amplitude * Mathf.PerlinNoise(xCoord, yCoord);
                noiseMap[x, y] = perlinValue;
            }
        }
    }

    void CreateMap()
    {
        

        Terrain terrain = GetComponent<Terrain>();
        TerrainData terrainData = terrain.terrainData;

        terrainData.SetHeights(0, 0, noiseMap);

    }
}
