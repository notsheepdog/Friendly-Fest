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

    void Start()
    {
        manager = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (levelOneState.paperSigned && !completed)
        {
            completed = true;
            sequenceRunning = true;
            runWinSequence();
        }
        else if(!sequenceRunning)
        {
            bossAnimator.SetInteger("StateManager", 0);
        }
    }

    private void runWinSequence()
    {
        bossAnimator.SetInteger("StateManager", 1);
        this.manager.StartDialogue(signingCompleted);
        sequenceRunning = false;
    }
}
