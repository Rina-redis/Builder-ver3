using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    [SerializeField]private ContextMenu contextMenu;
    private void OnMouseDown()
    {      
        contextMenu.TurnOnOff();
    }
}
