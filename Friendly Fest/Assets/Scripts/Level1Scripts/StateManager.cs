using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField] private Level1 levelOneState;
    public DialogueSO signingCompleted;
    public Animator bossAnimator;
    [SerializeField] private DialogueManager manager;
    private bool completed = false;
    private bool sequenceRunning = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (levelOneState.paperSigned && !completed)
        {
            completed = true;
            sequenceRunning = true;
            StartCoroutine(runWinSequence());
        }
        else if(!sequenceRunning)
        {
            bossAnimator.SetInteger("StateManager", 0);
        }
    }

    private IEnumerator runWinSequence()
    {
        yield return new WaitForSeconds(3);
        bossAnimator.SetInteger("StateManager", 1);
        this.manager.StartDialogue(signingCompleted);
        yield return new WaitForSeconds(1);
        sequenceRunning = false;
    }
}
