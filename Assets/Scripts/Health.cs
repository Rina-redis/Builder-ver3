using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 55f;
    [SerializeField] private float currentHealth;

    private bool isAlive;
    void Start()
    {
        currentHealth = maxHealth;
        isAlive = true;
    }
    public void TakeDamage(float amout)
    {
        currentHealth -= amout;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (!isAlive)
            return;

        isAlive = false;
        OnDie();
        Destroy(this.gameObject);
    }
    public virtual void OnDie()
    {
    }
}
