using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public GameObject serit;

    public void SeritiGizle()
    {
        serit.SetActive(false);
    }
}
