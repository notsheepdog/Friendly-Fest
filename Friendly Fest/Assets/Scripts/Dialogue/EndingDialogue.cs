using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingDialogue : MonoBehaviour
{
    private static bool endingVisited = false;
    public DialogueSO introDialogue;
    [SerializeField] DialogueManager dm;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startCelebration());
    }

    IEnumerator startCelebration()
    {
        yield return new WaitForSeconds(0.1f);
        if (!endingVisited)
        {
            DialogueManager dm = GameObject.FindObjectOfType<DialogueManager>();
            dm.StartDialogue(introDialogue);
            dm.DisplayNextSentence();
            endingVisited = true;
        }
    }
}
