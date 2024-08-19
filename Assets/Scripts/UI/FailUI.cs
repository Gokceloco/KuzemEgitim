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
        canvasGroup.DOFade(1, 1f);
    }

    public void Hide()
    {
        canvasGroup.DOFade(0, .2f);
    }

    public void RestartButtonClicked()
    {
        gameDirector.RestartLevel();
    }
}
