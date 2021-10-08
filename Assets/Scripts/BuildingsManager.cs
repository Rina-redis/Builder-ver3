using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BuildingManager : MonoBehaviour
{
    public int numberOfAliveBuildings = 0;
    public static event Action IncreaseNumberOfBuildings;
    public static event Action DecreaseNumberOfBuildings;
    private void Start()
    {
        IncreaseNumberOfBuildings += IncreaseNumber;
        DecreaseNumberOfBuildings += DencreaseNumber;
    }
    private void IncreaseNumber()
    {
        numberOfAliveBuildings++;
    }
    private void DencreaseNumber()
    {
        numberOfAliveBuildings--;
    }
}
