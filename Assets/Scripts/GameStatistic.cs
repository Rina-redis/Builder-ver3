using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatistic : MonoBehaviour
{
    [SerializeField] private float buildingsForWin = 5;

    private int aliveBuildings = 0;
    private float startTime = 0;
    private float currentTime;
    private BuildinsLiveTimer timer;

    private void Start()
    {
        timer = gameObject.GetComponent<BuildinsLiveTimer>();
    }
    private void StartCounting()
    {       
        timer.StartTimer();
    }
    private void StopCounting()
    {
        timer.Reset();
    }

    public delegate void OnChangedAliveBuildingsCount(int aliveBuildings);
    public event OnChangedAliveBuildingsCount onChangedAliveBuildingsCount;

    public void BuildingWasEaten()
    {
        aliveBuildings--;
        onChangedAliveBuildingsCount.Invoke(aliveBuildings);
        if (aliveBuildings <= buildingsForWin) //state
            StopCounting();


    }
    public void OnBuild()
    {
        aliveBuildings++;
        onChangedAliveBuildingsCount.Invoke(aliveBuildings );
        if (aliveBuildings == buildingsForWin) //state
            StartCounting();
    }
    
}
