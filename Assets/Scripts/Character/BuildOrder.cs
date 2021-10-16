using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStatistic))]
public class BuildOrder : MonoBehaviour
{
    [SerializeField] private GameObject currentObj;
    [SerializeField] private float delta = 3f;
    public GameObject[] objectsForBuilding;
    
    private Vector3 placeForBuilding;
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
        placeForBuilding = new Vector3(transform.position.x + delta, transform.position.y, transform.position.z);
        //StartCoroutine(readyToBuild());
        InstantiateObject();
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
    private void InstantiateObject()
    {
        Instantiate(currentObj, placeForBuilding, new Quaternion());
        characterStatistic.OnBuild();
        Game.Instance.gameStatistic.OnBuild();
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
