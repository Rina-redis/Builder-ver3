using Assets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSpawner : MonoBehaviour
{
    [SerializeField] private int countOfSpawners;
    [SerializeField] private string[] enemyTypes;
    private SpawnerFactory spawnerFactory;

    private void Start()
    {
        spawnerFactory = GetComponent<SpawnerFactory>();

        for (int i = 0; i < countOfSpawners; i++)
        {
            var spavner = spawnerFactory.GetSpavnerByType(enemyTypes[i]);
            Spawn(spavner);
        }
    }
    private void Spawn(GameObject Spavner)
    {
        Instantiate(Spavner, Spavner.transform.position, Quaternion.identity);
    }
}



