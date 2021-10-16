using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Text exp;
    [SerializeField] private Text lvl;
    [SerializeField] private Text aliveBuildings;
    [SerializeField] private Text timeOfLive;

    public void ChangeCharacterStatisticUI(float Exp, int Lvl)
    {
        exp.text = Exp.ToString();
        lvl.text = Lvl.ToString();
    }
    public void ChangeGameStatisticUI(int AliveBuildings)
    {
        aliveBuildings.text = AliveBuildings.ToString(); 
    }
    public void ChangeGameStatisticUI(float TimeOfLive)
    {
        timeOfLive.text = TimeOfLive.ToString();
    }
}
