using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStatistic))]
public class BuildOrder : MonoBehaviour
{
    private GameObject currentObj;
    [SerializeField] private float deltaForBuilding = 3f;
    public GameObject[] objectsForBuilding;
    
    
    private CharacterStatistic characterStatistic;
    private GameStatistic gameStatistic;
    // private bool isReadyToBuild = false;

    private void Start()
    {
        characterStatistic = GetComponent<CharacterStatistic>();
    }
    public void StartOrder()
    {
        currentObj = GetObjToBuild();
        TryToBuild();
    }
    
    private void TryToBuild()
    {
        Vector3 placeForBuilding = new Vector3(transform.position.x + deltaForBuilding, transform.position.y, transform.position.z);
        //StartCoroutine(readyToBuild());
        InstantiateObject(placeForBuilding);
        //  placeForBuilding = GetPlaceForBuilding();
    }
    private GameObject GetObjToBuild()
    {
        int numberOfObj = CharacterStatistic.currentLvl; 
        if (numberOfObj < objectsForBuilding.Length)
        {
            return objectsForBuilding[numberOfObj];
        }
        else
        {
            return objectsForBuilding[0];
        }
    }

    private void InstantiateObject(Vector3 placeForBuilding)
    {
        var spriteRenderer = currentObj.GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
            return;
        
        Bounds bound = spriteRenderer.bounds;
        bound.center = placeForBuilding;

        var intersectedObjects = Physics2D.OverlapAreaAll(bound.min, bound.max);
        bool canBuild = true;
        foreach (Collider2D collider in intersectedObjects)
        {
            if (collider.tag == "Building")
                canBuild = false;
        }

        if (canBuild)
        {
            Instantiate(currentObj, placeForBuilding, new Quaternion());
            characterStatistic.OnBuild();
            Game.Instance.gameStatistic.OnBuild();
        }       
    }
    
    //private IEnumerator readyToBuild()
    //{
    //    isReadyToBuild = true;
    //    yield return new WaitForSeconds(5);
    //    isReadyToBuild = false;
    //}
    //private Vector3 GetPlaceForBuilding()
    //{
    //    while (isReadyToBuild)
    //    {
    //        if (Input.GetMouseButtonDown(1))
    //        {
    //            Vector3 mousePos = Input.mousePosition;
    //            Debug.LogWarning("kuzdfuksedl");
    //            return mousePos;
    //        }
    //        Debug.Log("nea");
    //    }
    //    return new Vector3(0, 0, 0);
    //}
    //private void OnMouseDown()
    //{
    //    if (Input.GetMouseButtonDown(1) && isReadyToBuild)
    //    {
    //        Vector3 mousePos = Input.mousePosition;
    //    }
    //}

}
