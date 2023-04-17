using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelebrationDialogue : MonoBehaviour
{
    private static bool celebrationVisited = false;
    public DialogueSO introDialogue;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        if (!celebrationVisited)
        {
            Debug.Log("inside");
            DialogueManager dm = GameObject.FindObjectOfType<DialogueManager>();
            dm.StartDialogue(introDialogue);
            dm.DisplayNextSentence();
            celebrationVisited = true;
        }
        Debug.Log("done");
    }
}
