using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnBase : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            var state = collision.GetComponent<Enemy>();
            state.state = State.CanAttack;
        }
    }
}
