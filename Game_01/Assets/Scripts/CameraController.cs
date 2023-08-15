using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition =  Vector3.Lerp(transform.position, desiredPosition, smoothSpeed*Time.deltaTime);

        transform.position = smoothedPosition;

        transform.LookAt(target);
    }
}
