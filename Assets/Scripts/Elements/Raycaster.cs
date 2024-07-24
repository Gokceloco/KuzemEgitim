using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    public Transform otherCube;

    public Camera mainCamera;

    public LayerMask layerMask;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray.origin, ray.direction, out hit, 100, layerMask))
            {
                hit.transform.position = hit.transform.position + Vector3.up;
            }
        }
        
    }
}
