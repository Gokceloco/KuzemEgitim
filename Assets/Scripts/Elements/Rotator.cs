using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotateDuration;
    public Ease ease;
    public bool isInfinite;
    public LoopType loopType;

    private void Start()
    {
        if (isInfinite)
        {
            transform.DORotate(180 * Vector3.up, rotateDuration)
                .SetEase(Ease.Linear).SetLoops(-1, loopType)
                .SetDelay(Random.Range(0f,1f));
        }
        else
        {
            transform.DORotate(180 * Vector3.up, rotateDuration).SetEase(Ease.Linear);
        }
    }
}
