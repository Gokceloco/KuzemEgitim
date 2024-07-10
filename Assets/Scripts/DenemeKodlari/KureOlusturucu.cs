using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KureOlusturucu : MonoBehaviour
{
    public GameObject kurePrefab;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var yeniKure = Instantiate(kurePrefab);
            yeniKure.transform.position = new Vector3 (0, 0, 0);
            yeniKure.GetComponent<Rigidbody>().AddForce(new Vector3 (0, 0, Random.Range(10000, 20000)));
        }
    }
}
