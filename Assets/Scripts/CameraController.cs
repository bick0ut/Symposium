using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    private void FixedUpdate()
    {
        transform.right = target.position - transform.position;
        transform.LookAt(target);
    }
}
