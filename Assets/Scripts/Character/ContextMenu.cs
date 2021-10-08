using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextMenu : MonoBehaviour
{
    [SerializeField] private Transform target;
    private bool enabled;
    [SerializeField]private float delta = 5f;
    private void Start()
    {
        enabled = false;
    }
    private void FixedUpdate()
    {
       // gameObject.transform.position = new Vector3(target.position.x + delta, target.position.y + delta, target.position.z + delta);//gavno kakoeto
        transform.position = target.position + Vector3.one * delta;
        
    }
    public void TurnOnOff()
    {
        if (enabled)
        {
            gameObject.active = false;
            enabled = !enabled;
        }
        else
        {
            gameObject.active = true;
            enabled = !enabled;
        }
    }
}
