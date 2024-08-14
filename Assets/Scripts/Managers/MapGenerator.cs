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

    public Car carPrefab;

    public Transform carsParent;

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

        StartCoroutine(
            GenerateCarCoroutine(
                Random.value < .5f, 
                Random.Range(7f, 13f), 
                Random.Range(3f, 10f), 
                lastRowCount));

        lastRowCount += 1;
    }

    IEnumerator GenerateCarCoroutine(bool toLeft, float carTravelDuration, float carGenerationFreq, int row)
    {
        while (true)
        {
            var newCar = Instantiate(carPrefab, carsParent);
            newCar.StartCar(row, toLeft, carTravelDuration);
            yield return new WaitForSeconds(carGenerationFreq);
        }
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

    internal void DeleteMap()
    {
        throw new System.NotImplementedException();
    }
}
