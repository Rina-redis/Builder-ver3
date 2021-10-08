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
    [SerializeField] float damage = 10f;   
    [SerializeField] Transform spawnPosition;
    public State state = State.CanAttack;
    private Transform closestBuilding;
    private GameObject[] buildings;
    private NavMeshAgent agent;
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
    private void AiCycle()
    {
        switch (state)
        {
            case State.CanAttack:
                FindBuildingAndAttack();
                break;
            case State.GoToBase:
                agent.SetDestination(spawnPosition.position);
                break;
        }     
    }

    private void FindBuildingAndAttack()
    {
        buildings = FindAllBuildings();
        GameObject closestBuilding = ClosestBuilding(buildings);
        if (closestBuilding != null)
            agent.SetDestination(closestBuilding.transform.position);
    }

    private GameObject[] FindAllBuildings()
    {
        return buildings = GameObject.FindGameObjectsWithTag("building");
    }
    private GameObject ClosestBuilding(GameObject[] buildingsArray)
    {
        GameObject tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject t in buildingsArray)
        {
            float dist = Vector3.Distance(t.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        return tMin;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Character")
        {           
            state = State.GoToBase;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "building")
        {
            var healthComponent = collision.GetComponent<Health>();
            if (healthComponent != null)
            {
                Debug.LogWarning("col");
                healthComponent.TakeDamage(damage);
            }
        }
    }
}

