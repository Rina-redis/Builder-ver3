using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets
{
    class EnemyFactory : MonoBehaviour
    {
       // [SerializeField] private GameObject[] enemys;
        [SerializeField] private GameObject enemyPrefab;
        public GameObject GetEnemyByName(string Type)
        {
            var enemy = enemyPrefab;
            var enemyScript = enemy.GetComponent<Enemy>();
            enemyScript.spawnPosition = gameObject.transform.position;          
            return enemy;
        }
    }
}
