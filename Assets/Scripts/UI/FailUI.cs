using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailUI : MonoBehaviour
{
    public GameDirector gameDirector;
    public void RestartButtonClicked()
    {
        gameDirector.RestartLevel();
    }
}
