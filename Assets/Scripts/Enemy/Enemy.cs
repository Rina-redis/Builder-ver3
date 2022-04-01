using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum State
{
    CanAttack, GoToBase
}
public class Enemy : MonoBehaviour
{
    [SerializeField] protected float damage = 10f;
    [SerializeField] protected GameObject particles;
    [SerializeField] protected Color colorOnPlayerTouch;

    public State state = State.CanAttack;
    private Bush closestBush;
    private SpriteRenderer spriteRenderer;
    protected Transform closestBuilding;
    protected NavMeshAgent agent;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    private void Update()
    {
        AiCycle();
    }
    protected virtual void AiCycle()
    {
        switch (state)
        {
            case State.CanAttack:
                spriteRenderer.color = new Color(255, 255, 255); //white
                FindBuildingAndAttack();
                break;
            case State.GoToBase:

                if (closestBush == null)
                {
                    FindClosestBushPosition();
                }
                else
                {
                    agent.SetDestination(closestBush.transform.position);
                }
                break;
        }
    }


    private void FindClosestBushPosition()
    {
        closestBush = MathHelper.ClosestBush(gameObject.transform.position);
        closestBush.IsFree = false; //we reserve the bush only for us
    }

    protected void FindBuildingAndAttack()
    {
        GameObject[] buildings = FindAllBuildings();
        GameObject closestBuilding = MathHelper.ClosestGameobject(buildings, gameObject.transform.position);
        if (closestBuilding != null)
            agent.SetDestination(closestBuilding.transform.position);
    }

    protected GameObject[] FindAllBuildings()
    {
        GameObject[] buildings = GameObject.FindGameObjectsWithTag("Building");
        return buildings;
    }
    public void OnCollisionWithBush()
    {
        closestBush = null;
        state = State.CanAttack;
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Character" && state != State.GoToBase)
        {
            state = State.GoToBase;
            spriteRenderer.color = colorOnPlayerTouch;
            GameObject firework = Instantiate(particles, gameObject.transform.position, Quaternion.identity);
            firework.GetComponent<ParticleSystem>().Play();
        }
    }
    protected void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Building" && state == State.CanAttack)
        {
            var healthComponent = collision.GetComponent<Health>();
            if (healthComponent != null)
            {
                {
                    healthComponent.TakeDamage(damage);
                }
            }
        }
    }
}
