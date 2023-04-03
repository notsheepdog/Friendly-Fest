using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSOs : MonoBehaviour
{
    public Level1 lv1;
    public Level2SO lv2;

    private static bool gameStart = true; //is this the starting scene?

    // Start is called before the first frame update
    void Start()
    {
        if (gameStart)
        {
            lv1.paperSigned = false;
            lv2.ingreadientsFound = false;
            lv2.donutsCreated = false;
            //level3 stuffs here if applicable...
            gameStart = false;
        }
    }
}
