using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDeneme : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print("in trigger with player");
    }
}
