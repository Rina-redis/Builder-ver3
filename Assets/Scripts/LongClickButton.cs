using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LongClickButton : MonoBehaviour
{
    //private bool pointerDown;
    //private float poiterDownTimer;

    //public float requiredHoldTime;

    //public UnityEvent onLingClick;

    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    pointerDown = true;
    //}

    //public void OnPointerUp(PointerEventData eventData)
    //{
    //    Reset();
    //}
    //private void Update()
    //{
    //    if (pointerDown)
    //    {
    //        poiterDownTimer += Time.deltaTime;
    //        if(poiterDownTimer>= requiredHoldTime)
    //        {
    //            if(onLingClick != null)
    //            {
    //                onLingClick.Invoke();
    //            }
    //            Reset();
    //        }
    //    } 
    //}

    //private void Reset()
    //{
    //    pointerDown = false;
    //    poiterDownTimer = 0;
    //}

    [SerializeField]
    [Tooltip("How long must pointer be down on this object to trigger a long press")]
    private float holdTime = 1f;

    //private bool held = false;
    //public UnityEvent onClick = new UnityEvent();

    public UnityEvent onLongPress = new UnityEvent();

    public void OnPointerDown(PointerEventData eventData)
    {
        //held = false;
        Invoke("OnLongPress", holdTime);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        CancelInvoke("OnLongPress");

        //if (!held)
        //    onClick.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CancelInvoke("OnLongPress");
    }

    void OnLongPress()
    {
        //held = true;
        onLongPress.Invoke();
        Debug.LogWarning("dfgdfgsdff");
    }
}
