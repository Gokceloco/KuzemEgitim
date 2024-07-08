using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int mapXLength;
    public Transform blockPrefab;
    public void StartMapGenerator()
    {
        GenerateMap();
    }
    public void GenerateMap()
    {
        for (int i = 0; i < mapXLength; i++)
        {
            var newBlock = Instantiate(blockPrefab);
            newBlock.position = new Vector3(i, 0, 0);
        }
    }
}
