using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    [Header("Managers")]
    public MapGenerator mapGenerator;

    [Header("UI")]
    public PlayerScoreUI playerScoreUI;
    public FailUI failUI;

    [Header("Elements")]
    public Player player;
    public CameraHolder cameraHolder;

    // Start is called before the first frame update
    void Start()
    {
        RestartLevel();
    }

    public void UpdatePlayerScore(int playerScore)
    {
        playerScoreUI.UpdatePlayerScore(playerScore);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
    }

    public void RestartLevel()
    {
        failUI.RestartFailUI();
        player.ResetPlayer();
        cameraHolder.ResetCameraHolder();
        mapGenerator.DeleteMap();
        mapGenerator.GenerateMap();
    }
}
