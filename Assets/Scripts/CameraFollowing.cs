using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    [SerializeField]private Transform target;
    [SerializeField] private float cameraDistance = 30.0f;
    Vector3 targetPosition;
    private void Awake()
    {       
        GetComponent<Camera>().orthographicSize = ((Screen.height / 2) / cameraDistance);
    }
    private void FixedUpdate()
    {
        targetPosition = target.position;
        transform.position = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
    }
}
