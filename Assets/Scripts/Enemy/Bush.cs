using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour
{
    [SerializeField] private GameObject enemyToSpawn;
    public bool IsSpawner = false;
    public bool IsFree = true;

    public void SpawnEnemy()
    {
        IsSpawner = true;
        Instantiate(enemyToSpawn, gameObject.transform.position, Quaternion.identity);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            var enemy = collision.GetComponent<Enemy>();
            enemy.OnCollisionWithBush();
            BecomeFree();
        }
    }
    private void BecomeFree()
    {
        IsFree = true;
    }
}
