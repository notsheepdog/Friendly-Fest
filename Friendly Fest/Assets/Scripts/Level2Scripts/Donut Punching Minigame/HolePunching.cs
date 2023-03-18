using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolePunching : MonoBehaviour
{
    public DonutPunching_Manager manager;

    public Transform donut;
    public Transform hole;
    public AudioClip winSFX;
    public AudioClip failSFX;

    [Tooltip("how many units the hole can validly be from the center of the donut")]
    public int distanceAllowance;

    private bool moving = true;

    void Update()
    {
        Vector2 mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) * 44;

        if (moving)
        {
            hole.localPosition = mPos;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 dPos = donut.localPosition;

            if (Vector3.Distance(hole.localPosition, dPos) < distanceAllowance)
            {
                AudioSource.PlayClipAtPoint(winSFX, Camera.main.transform.position);
                donut.GetComponent<DonutMove>().moving = false;
                moving = false;

                manager.nextLevel();
            }
            else
            {
                AudioSource.PlayClipAtPoint(failSFX, Camera.main.transform.position);
                donut.GetComponent<DonutMove>().moving = false;
                moving = false;

                manager.failLevel();
            }
        }
    }

    public void resetHolePunching(Transform newDonut)
    {
        donut = newDonut;
        donut.localPosition = Vector3.zero;
        donut.GetComponent<DonutMove>().moving = true;
        moving = true;
    }
}
