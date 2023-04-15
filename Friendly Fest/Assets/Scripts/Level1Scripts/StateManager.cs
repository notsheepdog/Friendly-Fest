using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField] private Level1 levelOneState;
    public DialogueSO welcome;
    public DialogueSO signingCompleted;
    public Animator bossAnimator;
    [SerializeField] private DialogueManager manager;
    private bool completed = false;
    private bool sequenceRunning = false;
    private DisplayQuests displayer;

    public Task signPaper;
    public Task returnSignage;


    void Start()
    {
        manager = FindObjectOfType<DialogueManager>();
        displayer = FindObjectOfType<DisplayQuests>();

        if (levelOneState.paperSigned)
        {
            displayer.curTask = returnSignage;
            displayer.displayCurrentTask();
        } else if (!levelOneState.paperSigned)
        {
            this.manager.StartDialogue(welcome);
            this.manager.DisplayNextSentence();
            displayer.curTask = signPaper;
            displayer.displayCurrentTask();
        }

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
        this.manager.DisplayNextSentence();
        sequenceRunning = false;
    }
}
