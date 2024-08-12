using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScoreUI : MonoBehaviour
{
    public TextMeshProUGUI playerScoreTMP;

    public void UpdatePlayerScore(int playerScore)
    {
        playerScoreTMP.text = playerScore.ToString();
        playerScoreTMP.transform.DOKill();
        playerScoreTMP.transform.localScale = Vector3.one;
        playerScoreTMP.transform.DOScale(1.5f, .1f).SetLoops(2, LoopType.Yoyo);
    }
}
