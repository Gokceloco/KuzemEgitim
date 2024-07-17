using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HareketKontrol : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.DOMoveY(10, 1).SetEase(Ease.OutBack);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.DOMoveY(0, 1);
        }
    }
}
