using System;
using UnityEngine;

public class WinMenu : MonoBehaviour
{
    private Canvas canvas;
    private void Start()
    {
        canvas = gameObject.GetComponent<Canvas>();
        canvas.worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    public void InstantiateWinMenu()
    {
        Instantiate(gameObject, gameObject.transform.position, new Quaternion(0, 0, 0, 0));
    }
}