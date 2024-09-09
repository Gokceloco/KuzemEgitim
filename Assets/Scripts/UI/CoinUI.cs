using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    public TextMeshProUGUI coinTMP;

    private CanvasGroup _canvasGroup;
    public void Show()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.DOFade(1, .2f);
    }
    public void Hide()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.DOFade(0, .2f);
    }

    public void UpdateCoinCount()
    {
        coinTMP.text = PlayerPrefs.GetInt("CoinCount").ToString();
    }
}
