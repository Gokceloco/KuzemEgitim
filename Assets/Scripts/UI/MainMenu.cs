using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameDirector gameDirector;

    private CanvasGroup _canvasGroup;

    public void RestartMainMenu()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }
    public void Show()
    {
        gameObject.SetActive(true);
        _canvasGroup.DOFade(1, .2f);
    }

    public void Hide()
    {
        _canvasGroup.DOFade(0, .2f).OnComplete(SetActiveFalse);
    }

    void SetActiveFalse()
    {
        gameObject.SetActive(false);
    }

    public void PlayButtonClicked()
    {
        gameDirector.RestartLevel();
        Hide();
    }
}
