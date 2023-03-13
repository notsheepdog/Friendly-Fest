using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutMove : MonoBehaviour
{
    public float donutSpeed;

    [Tooltip("how many units left and right the donut can move")]
    public float xRange;
    [Tooltip("how many units up and down the donut can move")]
    public float yRange;

    [HideInInspector]
    public bool moving = true;

    private Vector3 direction;

    private void Start()
    {
        direction = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        direction = Vector3.Normalize(direction);
    }

    void Update()
    {
        if (!moving)
        {
            return;
        }

        Vector3 pos = transform.localPosition;
        if (Mathf.Abs(pos.x + direction.x) >= xRange)
        {
            direction.x = -direction.x;
            direction.y += Random.Range(-1f, 1f);
            direction = Vector3.Normalize(direction);
        }
        else if (Mathf.Abs(pos.y + direction.y) >= yRange)
        {
            direction.x += Random.Range(-1f, 1f);
            direction.y = -direction.y;
            direction = Vector3.Normalize(direction);
        }

        // in case donut somehow gets off screen, bring it back
        if (Vector3.Magnitude(pos) > 450)
        {
            transform.localPosition = Vector3.zero;
        }

        transform.position += direction * Time.deltaTime * donutSpeed;
    }
}
