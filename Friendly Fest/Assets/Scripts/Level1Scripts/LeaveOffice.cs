using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveOffice : MonoBehaviour
{
    public Level1 scriptableObj;


    private void MoveSceneIfPaperSigned()
    {
        if (scriptableObj.paperSigned)
        {
            FindObjectOfType<LevelManager>().MoveToNextScene();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (scriptableObj.paperSigned)
        {
            FindObjectOfType<LevelManager>().nextScene = 4;
            FindObjectOfType<LevelManager>().MoveToNextScene();
        }
    }
}
