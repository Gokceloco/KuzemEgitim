using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public PlayerScoreUI playerScoreUI;

    public MapGenerator mapGenerator;

    public Player player;
    public CameraHolder cameraHolder;

    // Start is called before the first frame update
    void Start()
    {
        mapGenerator.StartMapGenerator();
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

    private void RestartLevel()
    {
        // Player Position Resetle
        player.ResetPlayer();
        
        // Kameran�n pozisyonunu resetle
        cameraHolder.ResetCameraHolder();

        // Haritay� Sil
        //mapGenerator.DeleteMap();

        // Haritay� Yeniden Olu�tur
        // Player Skorunu 0la
    }
}
