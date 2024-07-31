using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public List<GameObject> carModels;
    public void StartCar(int row, bool toLeft, float carTravelDuration)
    {
        foreach (GameObject carModel in carModels)
        {
            carModel.SetActive(false);
        }
        carModels[UnityEngine.Random.Range(0, carModels.Count)].SetActive(true);

        if (toLeft)
        {
            transform.position = new Vector3(29f, 0, row);
            transform.DOMoveX(0, carTravelDuration).SetEase(Ease.Linear).OnComplete(DestroyCar);
            transform.Rotate(0,180,0);
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
