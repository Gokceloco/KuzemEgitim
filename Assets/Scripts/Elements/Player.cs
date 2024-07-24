using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera mainCamera;

    public bool karakterHareketEdiyorMu;
    public float karakterHareketSuresi;

    private Vector3 _dokunmaNoktasi;
    private Vector3 _birakmaNoktasi;

    public LayerMask layerMask;

    private void Update()
    {
        if (karakterHareketEdiyorMu)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            MoveUp();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            MoveDown();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray.origin, ray.direction, out hit, 100, layerMask))
            {
                _dokunmaNoktasi = hit.point;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray.origin, ray.direction, out hit, 100, layerMask))
            {
                _birakmaNoktasi = hit.point;
            }
            MoveCharacter(_birakmaNoktasi - _dokunmaNoktasi);
        }
    }   
    void MoveCharacter(Vector3 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.z))
        {
            if (direction.x < 0)
            {
                MoveLeft();
            }
            else
            {
                MoveRight();
            }
        }
        else
        {
            if (direction.z < 0)
            {
                MoveDown();
            }
            else
            {
                MoveUp();
            }
        }
    }

    void DoSquashAnimation()
    {
        transform.DOScaleY(.5f, .05f).SetLoops(2, LoopType.Yoyo).OnComplete(KarakterHareketiniBitir);
    }

    void KarakterHareketiniBitir()
    {
        karakterHareketEdiyorMu = false;
    }

    private void MoveRight()
    {
        transform.DOMoveX(transform.position.x + 1, karakterHareketSuresi).OnComplete(DoSquashAnimation);
        karakterHareketEdiyorMu = true;
        transform.LookAt(transform.position + Vector3.right);
        DoJumpAnimation();
    }
    private void MoveLeft()
    {
        transform.DOMoveX(transform.position.x - 1, karakterHareketSuresi).OnComplete(DoSquashAnimation);
        karakterHareketEdiyorMu = true;
        transform.LookAt(transform.position + Vector3.left);
        DoJumpAnimation();
    }
    private void MoveDown()
    {
        transform.DOMoveZ(transform.position.z - 1, karakterHareketSuresi).OnComplete(DoSquashAnimation);
        karakterHareketEdiyorMu = true;
        transform.LookAt(transform.position + Vector3.back);
        DoJumpAnimation();
    }
    private void MoveUp()
    {
        transform.DOMoveZ(transform.position.z + 1, karakterHareketSuresi).OnComplete(DoSquashAnimation);
        karakterHareketEdiyorMu = true;
        transform.LookAt(transform.position + Vector3.forward);
        DoJumpAnimation();
    }
    private void DoJumpAnimation()
    {
        transform.DOMoveY(1, karakterHareketSuresi * .5f).SetLoops(2, LoopType.Yoyo);
        transform.DOScaleY(1f, karakterHareketSuresi * .5f).SetLoops(2, LoopType.Yoyo);
        transform.DOScaleX(.3f, karakterHareketSuresi * .5f).SetLoops(2, LoopType.Yoyo);
        transform.DOScaleZ(.3f, karakterHareketSuresi * .5f).SetLoops(2, LoopType.Yoyo);
    }
}
