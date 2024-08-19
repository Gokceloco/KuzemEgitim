using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameDirector gameDirector;

    public Camera mainCamera;

    public bool karakterHareketEdiyorMu;
    public bool karakterOyunuKaybettiMi;
    public float karakterHareketSuresi;

    private Vector3 _dokunmaNoktasi;
    private Vector3 _birakmaNoktasi;

    public LayerMask layerMask;
    public LayerMask treeLayerMask;

    public int playerScore;

    public void ResetPlayer()
    {
        Invoke(nameof(HareketKilitleriniKaldir), .5f);
        transform.DOKill();
        transform.position = new Vector3(14,0,3);
        transform.localScale = new Vector3(.5f,.8f,.5f);
        transform.LookAt(transform.position + Vector3.forward);
        GetComponent<BoxCollider>().enabled = true;
        playerScore = 0;
        gameDirector.UpdatePlayerScore(playerScore);
    }

    private void HareketKilitleriniKaldir()
    {
        karakterHareketEdiyorMu = false;
        karakterOyunuKaybettiMi = false;
    }

    private void Update()
    {
        if (karakterOyunuKaybettiMi || karakterHareketEdiyorMu)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            MoveForward();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            MoveBack();
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
            if ((_birakmaNoktasi - _dokunmaNoktasi).magnitude < .1f)
            {
                MoveCharacter(transform.forward);
                return;
            }
            MoveCharacter(_birakmaNoktasi - _dokunmaNoktasi);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            PlayerFailed();
        }
    }

    private void PlayerFailed()
    {
        karakterOyunuKaybettiMi = true;
        GetComponent<BoxCollider>().enabled = false;
        transform.DOKill();
        transform.DOScaleY(.01f, .1f);
        transform.DOScaleX(1.1f, .1f);
        transform.DOScaleZ(1.1f, .1f);
        transform.DOMoveY(0, .1f);
        gameDirector.failUI.Show();
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
                MoveBack();
            }
            else
            {
                MoveForward();
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
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.right, out hit, 1, treeLayerMask))
        {
            return;
        }
        transform.DOMoveX(transform.position.x + 1, karakterHareketSuresi).OnComplete(DoSquashAnimation);
        karakterHareketEdiyorMu = true;
        transform.LookAt(transform.position + Vector3.right);
        DoJumpAnimation();
    }
    private void MoveLeft()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.left, out hit, 1, treeLayerMask))
        {
            return;
        }
        transform.DOMoveX(transform.position.x - 1, karakterHareketSuresi).OnComplete(DoSquashAnimation);
        karakterHareketEdiyorMu = true;
        transform.LookAt(transform.position + Vector3.left);
        DoJumpAnimation();
    }
    private void MoveBack()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.back, out hit, 1, treeLayerMask))
        {
            return;
        }
        transform.DOMoveZ(transform.position.z - 1, karakterHareketSuresi).OnComplete(DoSquashAnimation);
        karakterHareketEdiyorMu = true;
        transform.LookAt(transform.position + Vector3.back);
        DoJumpAnimation();
    }
    private void MoveForward()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, 1, treeLayerMask))
        {
            return;
        }
        transform.DOMoveZ(transform.position.z + 1, karakterHareketSuresi).OnComplete(DoSquashAnimation);
        karakterHareketEdiyorMu = true;
        transform.LookAt(transform.position + Vector3.forward);
        DoJumpAnimation();
        if (playerScore < transform.position.z - 2)
        {
            playerScore = Mathf.RoundToInt(transform.position.z - 2);
            gameDirector.UpdatePlayerScore(playerScore);
        }
    }
    private void DoJumpAnimation()
    {
        transform.DOMoveY(1, karakterHareketSuresi * .5f).SetLoops(2, LoopType.Yoyo);
        transform.DOScaleY(1f, karakterHareketSuresi * .5f).SetLoops(2, LoopType.Yoyo);
        transform.DOScaleX(.3f, karakterHareketSuresi * .5f).SetLoops(2, LoopType.Yoyo);
        transform.DOScaleZ(.3f, karakterHareketSuresi * .5f).SetLoops(2, LoopType.Yoyo);
    }
}
