using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Text exp;
    [SerializeField] private Text lvl;
    [SerializeField] private Text aliveBuildings;
    [SerializeField] private Text timeOfLive;
    [SerializeField] private Text goalAliveBuildings;
    [SerializeField] private Text goalTimeOfLive;

    private void Start()
    {
        goalAliveBuildings.text = Game.Instance.gameStatistic.buildingsForWin.ToString();
        goalTimeOfLive.text = Game.Instance.gameStatistic.timeForWin.ToString() +" s";
    }
    public void ChangeCharacterStatisticUI(float Exp, int Lvl)
    {
        exp.text = Exp.ToString();
        lvl.text = Lvl.ToString();
    }
    public void ChangeGameStatisticUI(int AliveBuildings)
    {
        aliveBuildings.text = AliveBuildings.ToString(); 
    }
    public void ChangeGameAliveTimeUI(float TimeOfLive)
    {
        timeOfLive.text = TimeOfLive.ToString();
    }

    public void ShowWinMenu()
    {
        throw new NotImplementedException();
    }
}
