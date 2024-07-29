using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public void StartCar(int row, bool toLeft, float carTravelDuration)
    {
        if (toLeft)
        {
            transform.position = new Vector3(29f, 0, row);
            transform.DOMoveX(0, carTravelDuration).SetEase(Ease.Linear).OnComplete(DestroyCar);
        }
        else
        {
            transform.position = new Vector3(0, 0, row);
            transform.DOMoveX(29f, carTravelDuration).SetEase(Ease.Linear).OnComplete(DestroyCar);
        }
    }

    void DestroyCar()
    {
        transform.DOKill();
        Destroy(gameObject);
    }
}
