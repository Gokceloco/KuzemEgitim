using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JumpCoroutine : MonoBehaviour
{
    public bool isJumping;
    private void Start()
    {
        StartCoroutine(DoJumpCoroutine());
    }
    IEnumerator DoJumpCoroutine()
    {
        while (true)
        {
            Jump();
            yield return new WaitForSeconds(1);
        }
    }

    void Jump()
    {
        isJumping = true;
        transform.DOMoveY(2, .3f).SetLoops(2, LoopType.Yoyo).OnComplete(SetIsJUmpingFalse);
    }

    void SetIsJUmpingFalse()
    {
        isJumping = false;
    }
}
