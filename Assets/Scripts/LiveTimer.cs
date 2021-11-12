using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveTimer : MonoBehaviour
{
    protected float startTime = 0f;
    protected float currentTime = 0f;

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
        OnUpdate();
    }
    protected virtual void OnUpdate()
    {
        if (startTime > 0)
        {
            currentTime += Time.deltaTime;
        }
    }
    public float TimeOfLive()
    {
        return currentTime - startTime;
    }
}
