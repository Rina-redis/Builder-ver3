using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatistic : MonoBehaviour
{
    private int aliveBuildings = 0;
    private float startTime = 0;
    private float buildingsForWin = 5;
    private float currentTime;
   
    private void StartCounting()
    {
        startTime = Time.time;
        StartCoroutine(TimeCounting());      
    }
 
    public delegate void OnChangedAliveBuildingsCount(int aliveBuildings);
    public event OnChangedAliveBuildingsCount onChangedAliveBuildingsCount;

    public delegate void OnChangedAliveTime( float timeOfLive);
    public event OnChangedAliveTime onChangedAliveTime;
    public void BuildingWasEaten()
    {
        aliveBuildings--;
        onChangedAliveBuildingsCount.Invoke(aliveBuildings);
    }
    public void OnBuild()
    {
        aliveBuildings++;
        onChangedAliveBuildingsCount.Invoke(aliveBuildings );
        if (aliveBuildings >= buildingsForWin)
            StartCounting();
    }
    IEnumerator TimeCounting()
    {
        //while (aliveBuildings >= buildingsForWin)
        //{
        //    currentTime += Time.deltaTime;
        //    onChangedAliveTime.Invoke(currentTime - startTime);      падает в бесконечный цикл
        //}
        yield return null;
    }
}
