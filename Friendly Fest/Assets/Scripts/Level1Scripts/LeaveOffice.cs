using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveOffice : MonoBehaviour
{
    public Level1 scriptableObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
            FindObjectOfType<LevelManager>().MoveToNextScene();
        }
    }
}
