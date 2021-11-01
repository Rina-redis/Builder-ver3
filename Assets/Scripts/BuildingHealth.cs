using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHealth : Health
{
    public override void OnDie()
    {
        Game.Instance.gameStatistic.BuildingWasEaten();
        base.OnDie();       
    }
}
