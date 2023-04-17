using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePlayOnStart : MonoBehaviour
{
    public static bool signingVisited = false;
    public DialogueSO introDialogue;

    // Start is called before the first frame update
    void Start()
    {
        if(!signingVisited)
        {
            DialogueManager dm = GameObject.FindObjectOfType<DialogueManager>();
            dm.StartDialogue(introDialogue);
            dm.DisplayNextSentence();
            signingVisited = true;
        }
    }
}
