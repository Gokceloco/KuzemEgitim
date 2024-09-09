using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FailUI : MonoBehaviour
{
    public GameDirector gameDirector;
    private CanvasGroup canvasGroup;

    public Button restartButton;

    public void RestartFailUI()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        canvasGroup.DOFade(1, 1f);
        restartButton.transform.DOKill();
        restartButton.transform.localScale = Vector3.one;
        restartButton.transform.DOScale(1.1f, .5f).SetLoops(-1, LoopType.Yoyo);
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
        print("in here");
        gameDirector.mainMenu.Show();
        Hide();
    }
}
