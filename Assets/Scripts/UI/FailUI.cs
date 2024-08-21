using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailUI : MonoBehaviour
{
    public GameDirector gameDirector;
    public CanvasGroup canvasGroup;

    public void RestartFailUI()
    {
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        canvasGroup.DOFade(1, 1f);
    }

    public void Hide()
    {
        canvasGroup.DOFade(0, .2f).OnComplete(SetActiveFalse);
    }

    void SetActiveFalse()
    {
        gameObject.SetActive(false);
    }

    public void RestartButtonClicked()
    {
        gameDirector.RestartLevel();
    }
    public void PrintDebug()
    {
        print("button clicked");
    }
}
