using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    [Header("Managers")]
    public MapGenerator mapGenerator;
    public CoinManager coinManager;
    public AudioManager audioManager;
    public FXManager fxManager;

    [Header("UI")]
    public PlayerScoreUI playerScoreUI;
    public FailUI failUI; 
    public CoinUI coinUI;
    public MainMenu mainMenu;

    [Header("Elements")]
    public Player player;
    public CameraHolder cameraHolder;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.RestartMainMenu();
        mainMenu.Show();

        //RestartLevel();
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
        if (Input.GetKeyDown(KeyCode.G))
        {
            coinManager.EarnCoins(1);
            print(coinManager.GetCoinCount());
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            coinManager.ResetCoinCount();
            coinUI.UpdateCoinCount();
        }
    }

    public void DeleteRow(int rowCount)
    {
        StartCoroutine(DeleteRowCoroutine(rowCount));
    }

    IEnumerator DeleteRowCoroutine(int rowCount)
    {
        for (int i = 0; i < rowCount; i++)
        {
            mapGenerator.DeleteRow();
            yield return new WaitForSeconds(.1f);
        }
    }

    public void RestartLevel()
    {
        failUI.RestartFailUI();
        player.ResetPlayer();
        cameraHolder.ResetCameraHolder();
        mapGenerator.DeleteMap();
        mapGenerator.AddNewRows(mapGenerator.mapZLength);
        coinUI.Show();
        coinUI.UpdateCoinCount();
    }
}
