using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public PlayerScoreUI playerScoreUI;

    public MapGenerator mapGenerator;

    // Start is called before the first frame update
    void Start()
    {
        mapGenerator.StartMapGenerator();
    }

    public void UpdatePlayerScore(int playerScore)
    {
        playerScoreUI.UpdatePlayerScore(playerScore);
    }
}
