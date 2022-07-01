using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    
    public Transform target;
    private float cameraSpeed = 10;
     public Vector3 distance ;
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + distance, cameraSpeed);
    }

}
