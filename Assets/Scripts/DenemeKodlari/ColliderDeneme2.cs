using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDeneme2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print("in trigger with car detector");
    }
}
