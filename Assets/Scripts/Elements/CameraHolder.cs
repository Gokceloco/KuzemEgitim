using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    public Transform player;

    Vector3 velocity;

    public float smoothTime;

    private void Update()
    {
        if (transform.position.z < player.position.z)
        {
            var targetPos = player.position;

            targetPos.x = transform.position.x;
            targetPos.y = 0;

            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
        }        
    }
}
