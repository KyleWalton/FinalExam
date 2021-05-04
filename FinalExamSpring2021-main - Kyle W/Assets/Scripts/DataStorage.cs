using System;
using UnityEngine;
using UnityEngine.UI;

public class DataStorage : MonoBehaviour
{
    //MainMenu Storage

    public InputField playerName;

    public Dropdown playerLives;

    public Slider playTime;

    public void Update()
    {
        Data.Instance.playerName = playerName.text;
        Data.Instance.playTime = (int)playTime.value;
        switch (playerLives.value)
        {
            default:
                Data.Instance.playerLives = 9;
                break;
            case 1:
                Data.Instance.playerLives = 8;
                break;
            case 2:
                Data.Instance.playerLives = 7;
                break;
            case 3:
                Data.Instance.playerLives = 6;
                break;
            case 4:
                Data.Instance.playerLives = 5;
                break;
            case 5:
                Data.Instance.playerLives = 4;
                break;
            case 6:
                Data.Instance.playerLives = 3;
                break;
            case 7:
                Data.Instance.playerLives = 2;
                break;
            case 8:
                Data.Instance.playerLives = 1;
                break;
            case 9:
                Data.Instance.playerLives = 0;
                break;
        }
    }
}