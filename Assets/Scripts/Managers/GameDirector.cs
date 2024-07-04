using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public bool isAppleEaten;

    public Transform player;
    public float speed;
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            player.position = player.position + Vector3.forward * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            player.position = player.position - Vector3.forward * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.position = player.position + Vector3.left * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.position = player.position - Vector3.left * speed;
        }
    }
}
