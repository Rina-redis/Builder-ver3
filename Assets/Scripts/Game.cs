using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameStatistic gameStatistic;
    public CharacterStatistic characterStatistic;
    public UI ui;

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
        gameStatistic.onChangedAliveTime += ui.ChangeGameAliveTimeUI;
    }

}
