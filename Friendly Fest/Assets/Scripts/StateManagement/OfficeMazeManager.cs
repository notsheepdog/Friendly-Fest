using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeMazeManager : MonoBehaviour
{
    public static bool visited;
    public DialogueSO introDialogue;
    public Task newTask;


    // Start is called before the first frame update
    void Start()
    {
        if (!visited)
        {
            DialogueManager dm = GameObject.FindObjectOfType<DialogueManager>();
            dm.StartDialogue(introDialogue);
            dm.DisplayNextSentence();
            visited = true;
        }
    }

}
