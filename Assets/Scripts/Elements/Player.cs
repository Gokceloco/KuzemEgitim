using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameDirector gameDirector;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Target"))
        {
            collision.gameObject.SetActive(false);
            gameDirector.isAppleEaten = true;
        }
    }
}
