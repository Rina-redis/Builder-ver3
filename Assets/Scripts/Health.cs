using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 55f;
    [SerializeField] private float currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(float amout)
    {
        currentHealth -= amout;
        if(currentHealth<=0)
        {
            Die();  
        }
    }
    public virtual void Die()
    {      
        GameObject.Destroy(this.gameObject);
    }
}
