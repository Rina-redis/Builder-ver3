using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildinsLiveTimer : LiveTimer
{
    public event System.Action<float> onChangedAliveTime;

    void Update()
    {
        OnUpdate();
    }
    protected override void OnUpdate()
    {
        if (startTime > 0)
        {
            currentTime += Time.deltaTime;
            onChangedAliveTime.Invoke(TimeOfLive());
            Game.Instance.CheckIfWin(TimeOfLive());
        }
    }
}
