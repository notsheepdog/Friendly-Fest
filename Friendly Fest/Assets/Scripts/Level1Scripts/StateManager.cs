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
    private TaskManager displayer;

    public Task signPaper;
    public Task returnSignage;


    void Start()
    {
        manager = FindObjectOfType<DialogueManager>();
        displayer = FindObjectOfType<TaskManager>();
        displayer.RenderTasks();

        if (levelOneState.paperSigned)
        {
            //displayer.ClearTasks();
            //displayer.AddTask(returnSignage);
        } else if (!levelOneState.paperSigned)
        {
            this.manager.StartDialogue(welcome);
            this.manager.DisplayNextSentence();
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (levelOneState.paperSigned && !completed)
        {
            completed = true;
            sequenceRunning = true;
            displayer.ClearTasks();
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
        levelOneState.paperSigned = true;
        sequenceRunning = false;
    }
}
