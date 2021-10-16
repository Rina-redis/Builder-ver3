using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHealth : Health
{
    public override void Die()
    {
        Game.Instance.gameStatistic.BuildingWasEaten();//иногда выполняеться 3 раза, почему.. непонятно
        base.Die();       
    }
}
