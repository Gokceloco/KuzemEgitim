using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool karakterHareketEdiyorMu;
    public float karakterHareketSuresi;
    private void Update()
    {
        if (karakterHareketEdiyorMu)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.DOMoveZ(transform.position.z + 1, karakterHareketSuresi).OnComplete(KarakterHareketiniBitir);
            transform.DOMoveY(1, karakterHareketSuresi * .5f).SetLoops(2, LoopType.Yoyo);
            karakterHareketEdiyorMu = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.DOMoveZ(transform.position.z - 1, karakterHareketSuresi).OnComplete(KarakterHareketiniBitir);
            karakterHareketEdiyorMu = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.DOMoveX(transform.position.x - 1, karakterHareketSuresi).OnComplete(KarakterHareketiniBitir);
            karakterHareketEdiyorMu = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.DOMoveX(transform.position.x + 1, karakterHareketSuresi).OnComplete(KarakterHareketiniBitir);
            karakterHareketEdiyorMu = true;
        }
    }

    void KarakterHareketiniBitir()
    {
        karakterHareketEdiyorMu = false;
    }
}
