using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextMenu : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float delta = 5f;
    private bool enabled;   
    private int maxAliveTime = 5;
    private LiveTimer aliveTimer = new LiveTimer();
    private void Start()
    {
        enabled = false;
       // aliveTimer = new LiveTimer();
    }
    private void FixedUpdate()
    {
     
        transform.position = target.position + Vector3.one * delta;
        Debug.Log(aliveTimer.TimeOfLive());
        if ( aliveTimer.TimeOfLive() > maxAliveTime)
        {
            gameObject.active = false;
            enabled = !enabled;
            aliveTimer.Reset();
        }
    }
    public void TurnOnOff()
    {
        if (enabled)
        {
            gameObject.active = false;
            enabled = !enabled;
            aliveTimer.Reset();
        }
        else
        {
            gameObject.active = true;
            aliveTimer.StartTimer();
            enabled = !enabled;
        }
    }
}
