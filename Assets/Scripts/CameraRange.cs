using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraRange : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D _map; //¬ы можете использовать, например Box2dCollider дл€ нагл€дности ограничени€.

    private Vector2 minXY;
    private Vector2 maxXY;
   [SerializeField] private Transform _cameraTarget;

    private void Awake()
    {
        transform.position = new Vector3(_cameraTarget.position.x, _cameraTarget.position.y, transform.position.z);
    }
    void Start()
    {       
        CalculateFrustum(); //—читаем "максимальный сдвиг"      
    }
  
    void FixedUpdate()
    {
        ClampedMove(_cameraTarget.position);
    }
 
    void ClampedMove(Vector2 newPosition)
    {
        float xValue = newPosition.x;
        float yValue = newPosition.y;

        xValue = Mathf.Clamp(xValue, minXY.y, minXY.x);
        yValue = Mathf.Clamp(yValue, maxXY.y, maxXY.x);
        gameObject.transform.position = new Vector3(xValue, yValue, gameObject.transform.position.z);
    }

    void CalculateFrustum()
    {
        var rate = (float)Screen.currentResolution.width / Screen.currentResolution.height;
        var bounds = _map.bounds;
        var min = bounds.min;
        var max = bounds.max;

        var size = gameObject.GetComponent<Camera>().orthographicSize;


        minXY = new Vector2(max.x - size * rate, min.x + size * rate);
        maxXY = new Vector2(max.y - size, min.y + size);
    }
}
