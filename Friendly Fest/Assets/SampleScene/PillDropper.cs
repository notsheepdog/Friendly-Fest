using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillDropper : MonoBehaviour
{
    public GameObject pill;
    public float interval;

    private bool dropping = false;

    void Update()
    {
        if (!dropping)
        {
            dropping = true;
            Invoke("resetDrop", interval);
            GameObject p = Instantiate(pill, transform);
            p.transform.eulerAngles = new Vector3(-5, Random.Range(0, 360), 0);

            float lowC = 0.6f;
            float hiC = 1f;
            int cB = Random.Range(1, 7);

            p.transform.GetChild(0).GetComponent<Renderer>().material.color = 
                new Color(
                    (cB == 1 || cB == 4 || cB == 5 ? lowC : hiC), 
                    (cB == 2 || cB == 4 || cB == 6 ? lowC + 0.05f : hiC), 
                    (cB == 3 || cB == 5 || cB == 6 ? lowC + 0.05f : hiC));
        }
    }

    void resetDrop()
    {
        dropping = false;
    }
}
