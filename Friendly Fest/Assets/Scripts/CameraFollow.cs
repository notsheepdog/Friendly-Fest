using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static bool pauseCamera;
    public Transform target;
    public float mouseSensitivity = 100;

    private float pitch;
    private float yaw;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        yaw = transform.rotation.eulerAngles.y;
    }

    void Update()
    {
        if (pauseCamera)
        {
            return;
        }

        pitch -= Input.GetAxis("Mouse Y");
        yaw += Input.GetAxis("Mouse X");
        pitch = Mathf.Clamp(pitch, -90f, 90f);
        while (yaw < 0f) { yaw += 360f; }
        while (yaw >= 360f) { yaw -= 360f; }

        transform.eulerAngles = new Vector3(pitch, yaw, 0);
        target.eulerAngles = new Vector3(0, yaw, 0);
    }
}
