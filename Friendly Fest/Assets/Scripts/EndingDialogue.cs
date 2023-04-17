using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingDialogue : MonoBehaviour
{
    private static bool endingVisited = false;
    public DialogueSO introDialogue;

    // Start is called before the first frame update
    void Start()
    {
        if (!endingVisited)
        {
            DialogueManager dm = GameObject.FindObjectOfType<DialogueManager>();
            dm.StartDialogue(introDialogue);
            dm.DisplayNextSentence();
            endingVisited = true;
        }
    }
}
