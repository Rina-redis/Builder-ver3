using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnBase : MonoBehaviour
{
    [SerializeField] GameObject[] enemysToSpawn;
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
        EnemyFabric();
    }

    private void EnemyFabric()
    {
        var enemy = Instantiate(enemysToSpawn[0], gameObject.transform.position, Quaternion.identity);
        var enemyScript = enemy.GetComponent<Enemy>();
        enemyScript.spawnPosition = gameObject.transform;
    }
}
