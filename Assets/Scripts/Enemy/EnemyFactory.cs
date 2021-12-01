using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets
{
    class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private GameObject[] enemys;
        public GameObject GetEnemyByName(string Type)
        {
            GameObject enemy = enemys[0];  
           
                var enemyScript = enemy.GetComponent<Enemy>();
                enemyScript.spawnPosition = gameObject.transform.position;
           
            return enemy;
        }
    }
}
