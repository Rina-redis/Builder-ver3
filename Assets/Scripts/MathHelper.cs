using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathHelper : MonoBehaviour
{
    public static GameObject ClosestGameobject(GameObject[] buildingsArray, Vector3 currentPos)
    {
        GameObject tMin = null;
        float minDist = Mathf.Infinity;
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
    public static Bush ClosestBush(Vector3 currentPos)
    {
        Bush tMin = null;
        float minDist = Mathf.Infinity;
        foreach (Bush t in Game.Instance.bushManager.bushArray)
        {
            if (t.IsFree)// very important 
            {
                float dist = Vector3.Distance(t.transform.position, currentPos);
                if (dist < minDist)
                {
                    tMin = t;
                    minDist = dist;
                }
            }
        }
        return tMin;
       
    }
}
