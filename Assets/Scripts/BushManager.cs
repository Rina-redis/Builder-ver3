using Assets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushManager : MonoBehaviour
{
    private GameObject[] bushArray;
    [SerializeField] private int numberOfBushSpawners;
    private void Start()
    {
        bushArray = GameObject.FindGameObjectsWithTag("Bush");
        CreteBushSpawners();
    }

    private void CreteBushSpawners()
    {
       foreach(GameObject bush in bushArray)
        {
            Bush bushScript = bush.GetComponent<Bush>();
            bushScript = new BushSpawner();
            //bush.AddComponent<EnemyFactory>();
        }
    }
}
