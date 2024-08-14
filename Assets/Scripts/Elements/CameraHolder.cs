using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    public Transform player;

    Vector3 velocity;
    Vector3 velocity2;

    public float smoothTime;

    public bool isCameraFollowingBackwards;

    private void Update()
    {
        if (transform.position.z < player.position.z || isCameraFollowingBackwards)
        {
            var targetPos = player.position;

            targetPos.x = transform.position.x;
            targetPos.y = 0;

            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
        }
        if (Mathf.RoundToInt((transform.position - player.transform.position).magnitude) == 0)
        {
            isCameraFollowingBackwards = false;
        }
    }

    public void ResetCameraHolder()
    {        
        isCameraFollowingBackwards = true;
    }
}
