using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public Transform map;

    public int mapXLength;
    public int mapZLength;

    public int safeZoneLength;

    public Block denemeObjesi;

    public Block asphaltBlockPrefab;
    public Block grassBlockPrefab;

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
                    GenerateAsphaltRow(true);
                    for (int i = 0; i < Random.Range(1,6); i++)
                    {
                        GenerateAsphaltRow(false);
                    }
                    GenerateGrassRow();
                }
                else
                {
                    GenerateGrassRow();
                }
            }            
        }
    }
    public void GenerateAsphaltRow(bool seritGizlensinmi)
    {
        for (int i = 0; i < mapXLength; i++)
        {
            var newBlock = Instantiate(asphaltBlockPrefab, map);
            newBlock.transform.position = new Vector3(i, 0, lastRowCount);
            if (seritGizlensinmi)
            {
                newBlock.SeritiGizle();
            }
        }
        lastRowCount += 1;
        // eger bu ilk asfalt ise þeriti kaldýr
    }
    public void GenerateGrassRow()
    {
        for (int i = 0; i < mapXLength; i++)
        {
            var newBlock = Instantiate(grassBlockPrefab, map);
            newBlock.transform.position = new Vector3(i, 0, lastRowCount);
            if (lastRowCount > safeZoneLength)
            {
                if (Random.value < treeSpawnChance)
                {
                    var newTree = Instantiate(treePrefab, map);
                    newTree.position = new Vector3(i, 0, lastRowCount);
                }
            }
        }
        lastRowCount += 1;
    }
}
