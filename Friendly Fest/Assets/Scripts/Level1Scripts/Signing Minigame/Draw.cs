using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Draw : MonoBehaviour
{
    public Camera cam;
    public GameObject pen;

    LineRenderer lineRenderer;

    Vector2 lastPos;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // creates a new brush stroke and initializes it with two starting points

            lineRenderer = Instantiate(pen, transform).GetComponent<LineRenderer>();

            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            lineRenderer.SetPosition(0, mousePos);
            lineRenderer.SetPosition(1, mousePos);
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            // adds new points to the current brush stroke

            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            if (lastPos != mousePos)
            {
                lineRenderer.positionCount++;
                int positionIndex = lineRenderer.positionCount - 1;
                lineRenderer.SetPosition(positionIndex, mousePos);
                lastPos = mousePos;
            }
        }
    }
}