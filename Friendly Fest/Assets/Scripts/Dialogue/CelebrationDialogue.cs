using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelebrationDialogue : MonoBehaviour
{
    private static bool celebrationVisited = false;
    public DialogueSO introDialogue;

    [SerializeField] DialogueManager dm;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startCelebration());
    }

    IEnumerator startCelebration()
    {
        yield return new WaitForSeconds(.01f);
        if (!celebrationVisited)
        {
            dm.StartDialogue(introDialogue);
            dm.DisplayNextSentence();
            celebrationVisited = true;
        }
    }
}
