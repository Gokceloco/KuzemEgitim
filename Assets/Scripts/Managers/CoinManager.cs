using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public void ResetCoinCount()
    {
        PlayerPrefs.SetInt("CoinCount", 0);
    }

    public void EarnCoins(int count)
    {
        PlayerPrefs.SetInt("CoinCount", PlayerPrefs.GetInt("CoinCount") + count);
    }

    public int GetCoinCount()
    {
        return PlayerPrefs.GetInt("CoinCount");
    }
}
