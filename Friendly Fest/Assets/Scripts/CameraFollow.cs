using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public float mouseSensitivity = 100;

    Vector3 localOffset;
    Vector3 prevTargetPosition;
    Vector3 targetPosChange;
    float pitch;


    void Start()
    {
        localOffset = this.transform.localPosition;
        prevTargetPosition = target.transform.position;
        pitch = transform.rotation.x;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (!Cursor.visible)
        {
            float moveX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float moveY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            target.transform.Rotate(Vector3.up * moveX);

            pitch -= moveY;
            pitch = Mathf.Clamp(pitch, -90f, 90f);
            transform.localRotation = Quaternion.Euler(pitch, 0, 0);
        }
    }
}
