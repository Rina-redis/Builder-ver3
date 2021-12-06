using Assets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushManager : MonoBehaviour
{
    public GameObject[] bushGOArray;
    public Bush[] bushArray;
    [SerializeField] private int countOfEnemys;
    private void Start()
    {
        bushGOArray = GameObject.FindGameObjectsWithTag("Bush");
        GetBushes();
        CreteEnemys(countOfEnemys);
    }

    private void GetBushes()
    {
        bushArray = Array.ConvertAll(bushGOArray, n => n.GetComponent<Bush>());
    }
    private void CreteEnemys(int numberOfEnemys)
    {
        int numberOfSpawners = bushGOArray.Length;

        for (int i = 0; i < numberOfEnemys; i++)
        {
            System.Random rand = new System.Random();
            int randomBush = rand.Next(0, numberOfSpawners);

            if(bushGOArray[randomBush].GetComponent<Bush>() != null)
            {
                Bush bushScript = bushGOArray[randomBush].GetComponent<Bush>();
                if(bushScript.IsSpawner != true)
                {
                    bushScript.SpawnEnemy();
                }
                else
                {
                    i--;
                }
            }
        }
    }
}
