using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets;

public class BushSpawner : Bush
{
    //[SerializeField] public string typeOfEnemy;
    //public BushSpawner (string TypeOfEnemy)
    //{
    //    typeOfEnemy = TypeOfEnemy;
    //}
    //private EnemyFactory enemyFactory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            var state = collision.GetComponent<Enemy>();
            state.state = State.CanAttack;
        }
    }
    private void Start()
    {
        //enemyFactory = GetComponent<EnemyFactory>();
        //var enemy = enemyFactory.GetEnemyByName(typeOfEnemy);
        Spawn(enemyToSpawn);
    }
    private void Spawn(GameObject enemy)
    {
        var enemyTest = Instantiate(enemy, gameObject.transform.position, Quaternion.identity);
        enemyTest.transform.SetParent(gameObject.transform);
  
      }
    }
