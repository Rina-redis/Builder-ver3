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
            GameObject enemy = new GameObject();           
            if(enemys.Length != 0)
            {
                switch (Type)
                {
                    case "CatEnemy":
                        enemy = enemys[0];
                        break;
                }
                var enemyScript = enemy.GetComponent<Enemy>();
                enemy.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
                enemyScript.spawnPosition = gameObject.transform;         
            }
            return enemy;
        }
    }
}
