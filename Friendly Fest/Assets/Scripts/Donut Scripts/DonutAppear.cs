using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutAppear : MonoBehaviour
{
    public Level2SO state;
    public GameObject tray;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (state.donutsCreated && state.ingreadientsFound)
        {
            tray.SetActive(true);
        }
        else
        {
            tray.SetActive(false);
        }
    }
}
