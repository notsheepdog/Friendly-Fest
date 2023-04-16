using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePlayOnStart : MonoBehaviour
{
    private static bool visited = false;
    public DialogueSO introDialogue;

    // Start is called before the first frame update
    void Start()
    {
        if(!visited)
        {
            DialogueManager dm = GameObject.FindObjectOfType<DialogueManager>();
            dm.StartDialogue(introDialogue);
            dm.DisplayNextSentence();
            visited = true;
        }
    }
}
