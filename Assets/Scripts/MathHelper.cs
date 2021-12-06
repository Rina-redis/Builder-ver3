using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathHelper : MonoBehaviour
{
    private void Start()
    {
        
    }
    public static Bush ClosestBush(Vector3 currentPos)
    {
        Vector3 tMin = new Vector3();
        float minDist = Mathf.Infinity;
        foreach (Bush t in Game.Instance.bushManager.bushArray)
        {
            if (t.IsFree)
            {
                float dist = Vector3.Distance(t.transform.position, currentPos);
                if (dist < minDist)
                {
                    tMin = t.transform.position;
                    minDist = dist;
                    return t;
                }
            }         
        }
        return new Bush();
    }
}
