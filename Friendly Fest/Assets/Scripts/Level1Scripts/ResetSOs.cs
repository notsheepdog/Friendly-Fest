using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSOs : MonoBehaviour
{
    public Level1 lv1;
    public Level2SO lv2;
    public List<Task> resetTasks;

    private static bool gameStart = true; //is this the starting scene?

    // Start is called before the first frame update
    void Awake()
    {
        if (gameStart)
        {
            lv1.paperSigned = false;
            lv2.papersReturned = false;
            lv2.ingreadientsFound = false;
            lv2.ingredientsReturned = false;
            lv2.donutsCreated = false;
            lv2.itemsTraded = false;
            //level3 stuffs here if applicable...
            foreach(Task t in resetTasks)
            {
                t.completed = false;
            }

            gameStart = false;
        }
    }
}
