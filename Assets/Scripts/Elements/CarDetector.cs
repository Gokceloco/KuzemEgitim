using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDetector : MonoBehaviour
{
    public Player player;

    private void Update()
    {
        transform.position = player.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            var car = other.GetComponent<Car>();
            if ((car.isCarDirectionLeft && transform.position.x < other.transform.position.x) 
                || (!car.isCarDirectionLeft && transform.position.x > other.transform.position.x))
            {
                player.gameDirector.audioManager.PlayHornSound();
            }
        }
    }
}
