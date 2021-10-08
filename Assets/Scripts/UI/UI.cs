using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Text exp;
    [SerializeField] private Text lvl;
    private void Start()
    {
        Levels.onChangedTxt += ChangeExpAndLvlTxt;
    }
    private void ChangeExpAndLvlTxt(float Exp, int Lvl)
    {
        exp.text = Exp.ToString();
        lvl.text = Lvl.ToString();    
    }
    
}
