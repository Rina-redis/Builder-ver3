using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    [SerializeField] public static int currentLvl = 0;
    [SerializeField] private float currentExp = 0f;
    private int aliveBuildings = 0;
    private float expToRaiseLvl = 100f;
    private float expForOneBuild = 20f;
    private float deltaExpForLvl = 1.3f;

    public delegate void OnChangedTxt(float exp, int lvl);
    public static event OnChangedTxt onChangedTxt;
    private void IncreaseIndicators()
    {
        aliveBuildings++;
        currentExp += expForOneBuild;
        TryToIncreaseLvl(currentExp);
        onChangedTxt.Invoke(currentExp, currentLvl);
    }
    private void Start()
    {
        BuildOrder.onBuild += IncreaseIndicators; //problems with architecture
    }
    private void TryToIncreaseLvl(float exp)
    {
        if (exp >= expToRaiseLvl)
        {
            IncreaseLvlAndExp();
        }
    }
    private void IncreaseLvlAndExp()
    {
        currentLvl++;
        currentExp -= expToRaiseLvl;
        expToRaiseLvl *= deltaExpForLvl;
    }
  
}
