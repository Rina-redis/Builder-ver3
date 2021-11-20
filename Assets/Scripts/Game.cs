using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameStatistic gameStatistic;
    public CharacterStatistic characterStatistic;
    public BuildinsLiveTimer buildinsLiveTimer;
    public WinMenu winMenu;
    public UI ui;
    private bool IsGameEnded = false;

    private static Game instance;
    public static Game Instance
    {
        get
        {
            return instance;
        }
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        characterStatistic.onChangedTxt += ui.ChangeCharacterStatisticUI;
        gameStatistic.onChangedAliveBuildingsCount += ui.ChangeGameStatisticUI;
        buildinsLiveTimer.onChangedAliveTime += ui.ChangeGameAliveTimeUI;
    }

    public void CheckIfWin( float timeOfLive)
    {
        if (timeOfLive >= gameStatistic.timeForWin && !IsGameEnded)
        {
            EndGame();
        }
    }
    private void EndGame()
    {
        IsGameEnded = true;
        winMenu.InstantiateWinMenu();
    }
}
