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
    public Vector3 spawnPosition;
    public State state = State.CanAttack;
    public Bush closestBush;
    protected Transform closestBuilding;
    protected GameObject[] buildings;
    protected NavMeshAgent agent;
    private void Start()
    {
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
        buildings = FindAllBuildings();
        GameObject closestBuilding = MathHelper.ClosestGameobject(buildings, gameObject.transform.position);
        if (closestBuilding != null)
            agent.SetDestination(closestBuilding.transform.position);
    }

    protected GameObject[] FindAllBuildings()
    {
        return buildings = GameObject.FindGameObjectsWithTag("Building");
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
        }
    }
    protected void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag == "Building")
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
