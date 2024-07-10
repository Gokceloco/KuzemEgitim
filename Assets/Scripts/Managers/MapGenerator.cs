using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int mapXLength;
    public int mapZLength;

    public int safeZoneLength;

    public Transform asphaltBlockPrefab;
    public Transform grassBlockPrefab;
    public Transform treePrefab;

    public int lastRowCount;

    public float treeSpawnChance;

    public void StartMapGenerator()
    {
        GenerateMap();
    }
    public void GenerateMap()
    {
        for (int z = 0; z < mapZLength; z++)
        {
            if (z < safeZoneLength)
            {
                GenerateGrassRow();
            }
            else
            {
                if (Random.value < .5f)
                {
                    GenerateAsphaltRow();
                    GenerateAsphaltRow();
                }
                else
                {
                    GenerateGrassRow();
                }
            }            
        }
    }
    public void GenerateAsphaltRow()
    {
        for (int i = 0; i < mapXLength; i++)
        {
            var newBlock = Instantiate(asphaltBlockPrefab);
            newBlock.position = new Vector3(i, 0, lastRowCount);
        }
        lastRowCount += 1;
    }
    public void GenerateGrassRow()
    {
        for (int i = 0; i < mapXLength; i++)
        {
            var newBlock = Instantiate(grassBlockPrefab);
            newBlock.position = new Vector3(i, 0, lastRowCount);
            if (lastRowCount > safeZoneLength)
            {
                if (Random.value < treeSpawnChance)
                {
                    var newTree = Instantiate(treePrefab);
                    newTree.position = new Vector3(i, 0, lastRowCount);
                }
            }
        }
        lastRowCount += 1;
    }
}
