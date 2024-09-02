using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DORotate(180 * Vector3.up, 1.5f).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
        transform.DOMoveY(transform.position.y + .25f, 1).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutQuad);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
