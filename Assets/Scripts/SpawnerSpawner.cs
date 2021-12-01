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
            var spawner = spawnerFactory.GetSpavnerByType(enemyTypes[i]);
            Spawn(spawner);
            Debug.Log(spawner.transform.rotation);
        }
    }
    private void Spawn(GameObject spawner)
    {
        var enemySpawner = Instantiate(spawner, spawner.transform.position, Quaternion.identity);
        enemySpawner.transform.SetParent(gameObject.transform);

    }
}



