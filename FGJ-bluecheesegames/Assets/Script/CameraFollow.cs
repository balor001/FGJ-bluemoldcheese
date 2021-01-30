using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    
    public float smoothing = 0.125f;
    public Vector3 offset;

    public Vector3 test;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothing * Time.fixedDeltaTime);
        transform.position = smoothPosition;
        test = smoothPosition;
    }
}
