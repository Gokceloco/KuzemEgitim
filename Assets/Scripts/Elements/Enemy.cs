using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameDirector gameDirector;
    public float speed;

    private void Update()
    {
        if (gameDirector.isAppleEaten)
        {
            var dir = (gameDirector.player.position - transform.position).normalized;

            transform.position = transform.position + dir * speed;
        }
    }
}
