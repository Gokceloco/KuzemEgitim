using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public Transform map;
    public Transform carsParent;

    public int mapXLength;
    public int mapZLength;

    public int safeZoneLength;

    public Block denemeObjesi;

    public Block asphaltBlockPrefab;
    public Block grassBlockPrefab;

    public Transform treePrefab;
    public Car carPrefab;
    public Transform coinPrefab;

    public int lastRowCount;

    public float treeSpawnChance;      

    public List<Coroutine> carCoroutines = new List<Coroutine>();

    public int difficultyScalingRowCount;
    public float minCarGenerationFreq;
    public float minCarTravelDuration;

    public void StartMapGenerator()
    {
        AddNewRows(mapZLength);
    }
    public void AddNewRows(int rowCount)
    {
        for (int z = 0; z < rowCount; z++)
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
        var newRow = new GameObject("Asphalt Row");
        for (int i = 0; i < mapXLength; i++)
        {
            var newBlock = Instantiate(asphaltBlockPrefab, newRow.transform);
            newBlock.transform.position = new Vector3(i, 0, lastRowCount);
            if (seritGizlensinmi)
            {
                newBlock.SeritiGizle();
            }
        }

        var carTravelDuration = Random.Range(8f, 14f) - lastRowCount / difficultyScalingRowCount;
        var carGenerationFreq = Random.Range(4f, 11f) - lastRowCount / difficultyScalingRowCount;

        carTravelDuration = Mathf.Max(carTravelDuration, minCarTravelDuration - Random.Range(0f,1f));
        carGenerationFreq = Mathf.Max(carGenerationFreq, minCarGenerationFreq - Random.Range(0f, 1f));

        if (lastRowCount > 20 && Random.value < .2f)
        {
            if (Random.value < .5f)
            {
                carTravelDuration = Random.Range(12f, 14f);
                carGenerationFreq = Random.Range(2f, 3f);
            }
            else
            {
                carTravelDuration = Random.Range(3f, 4f);
                carGenerationFreq = Random.Range(10f, 11f);
            }            
        }

        var newCoroutine = StartCoroutine(GenerateCarCoroutine(
                Random.value < .5f, carTravelDuration, carGenerationFreq, lastRowCount, newRow));
        carCoroutines.Add(newCoroutine);

        newRow.transform.SetParent(map);

        lastRowCount += 1;
    }
    IEnumerator GenerateCarCoroutine(bool toLeft, float carTravelDuration, float carGenerationFreq, int row, GameObject newRow)
    {
        while (true)
        {
            var newCar = Instantiate(carPrefab, newRow.transform);
            newCar.StartCar(row, toLeft, carTravelDuration);
            yield return new WaitForSeconds(carGenerationFreq);
        }
    }
    public void GenerateGrassRow()
    {
        var newRow = new GameObject("Grass Row");
        for (int i = 0; i < mapXLength; i++)
        {
            var newBlock = Instantiate(grassBlockPrefab, newRow.transform);
            newBlock.transform.position = new Vector3(i, 0, lastRowCount);
            if (lastRowCount > safeZoneLength)
            {
                if (Random.value < treeSpawnChance)
                {
                    var newTree = Instantiate(treePrefab, newRow.transform);
                    newTree.position = new Vector3(i, 0, lastRowCount);
                }
                else if (Random.value < .2f)
                {
                    var newCoin = Instantiate(coinPrefab, newRow.transform);
                    newCoin.position = new Vector3(i, 0, lastRowCount);
                }
            }
        }
        newRow.transform.SetParent(map);
        lastRowCount += 1;
    }

    public void DeleteMap()
    {
        foreach (Transform t in map)
        {
            Destroy(t.gameObject);
        }
        foreach (Transform t in carsParent)
        {
            Destroy(t.gameObject);
        }
        foreach (Coroutine c in carCoroutines)
        {
            StopCoroutine(c);
        }
        carCoroutines.Clear();
        lastRowCount = 0;
    }

    public void DeleteRow()
    {
        var tempList = new List<GameObject>();

        foreach (Transform row in map)
        {
            tempList.Add(row.gameObject);
        }

        if (tempList[0].name == "Asphalt Row")
        {
            StopCoroutine(carCoroutines[0]);
            carCoroutines.RemoveAt(0);
        }

        Destroy(tempList[0]);
    }
}
