using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float speed;
    Vector3 pivot = Vector3.zero;

    void Update()
    {
        transform.LookAt(pivot);
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
