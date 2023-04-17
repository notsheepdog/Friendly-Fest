using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutPunchStart : MonoBehaviour
{
    private static bool donutVisited = false;
    public DialogueSO introDialogue;

    // Start is called before the first frame update
    void Start()
    {
        if (!donutVisited)
        {
            DialogueManager dm = GameObject.FindObjectOfType<DialogueManager>();
            dm.StartDialogue(introDialogue);
            dm.DisplayNextSentence();
            donutVisited = true;
        }
    }
}
