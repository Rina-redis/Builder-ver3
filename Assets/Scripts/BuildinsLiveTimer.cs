using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildinsLiveTimer : MonoBehaviour
{
    private float startTime = 0f;
    private float currentTime = 0f;
 
    public event System.Action<float> onChangedAliveTime;

    public void StartTimer()
    {
        startTime = Time.time;
        currentTime = startTime;
    }
    public void Reset()
    {
        startTime = 0f;
        currentTime = 0f;
    }
    void Update()
    {
        if (startTime > 0)
        {
            currentTime += Time.deltaTime;
            onChangedAliveTime.Invoke(TimeOfBuilddingsLive());
        }       
    }
    public float TimeOfBuilddingsLive()
    {
        return currentTime - startTime;
    }
    //public void ResetTimer()
    //{
    //    startTime = 0f;
    //    currentTime = 0f;
    //}
}
