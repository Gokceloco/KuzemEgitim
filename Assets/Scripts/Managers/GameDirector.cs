using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public MapGenerator mapGenerator;

    // Start is called before the first frame update
    void Start()
    {
        mapGenerator.StartMapGenerator();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
