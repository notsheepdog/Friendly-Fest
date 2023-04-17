using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyStateHandler : MonoBehaviour
{
    public static bool visited;
    public DialogueSO introDialogue;
    private TaskManager displayer;


    // Start is called before the first frame update
    void Start()
    {
        displayer = GameObject.FindObjectOfType<TaskManager>();
        if (!visited)
        {
            DialogueManager dm = GameObject.FindObjectOfType<DialogueManager>();
            dm.StartDialogue(introDialogue);
            dm.DisplayNextSentence();
            visited = true;
        }
    }

}
