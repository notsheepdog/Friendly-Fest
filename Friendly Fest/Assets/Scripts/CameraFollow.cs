using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    Vector3 localOffset;

    // Start is called before the first frame update
    void Start()
    {
        localOffset = this.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = this.localOffset + target.transform.position;
        this.transform.position = newPosition;
    }
}
