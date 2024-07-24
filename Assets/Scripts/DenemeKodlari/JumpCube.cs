using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCube : MonoBehaviour
{
    public float jumpForce;
    public float torqueForce;

    public LayerMask layerMask;
    public float distanceToGround;

    private bool _isTouchingGround;

    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.down*distanceToGround, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, distanceToGround, layerMask))
        {
            _isTouchingGround = true;
        }
        else
        {
            _isTouchingGround = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && _isTouchingGround)
        {
            Jump();
        }
    }

    private void Jump()
    {
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(Vector3.up * jumpForce);
        rigidbody.AddTorque(new Vector3(45,45,45) * torqueForce);
    }
}
