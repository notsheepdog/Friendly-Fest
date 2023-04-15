using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyStateHandler : MonoBehaviour
{
    private static bool visited;
    public DialogueSO introDialogue;
    public Task newTask;
    private DisplayQuests displayer;


    // Start is called before the first frame update
    void Start()
    {
        displayer = GameObject.FindObjectOfType<DisplayQuests>();
        if (!visited)
        {
            DialogueManager dm = GameObject.FindObjectOfType<DialogueManager>();
            dm.StartDialogue(introDialogue);
            dm.DisplayNextSentence();
            visited = true;
            displayer.curTask = newTask;
            displayer.displayCurrentTask();
        }
    }

}
