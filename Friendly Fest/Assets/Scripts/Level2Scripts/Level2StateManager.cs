using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2StateManager : MonoBehaviour
{
    [SerializeField] private Level2SO levelTwoState;
    public DialogueSO ingredientsPrompt;
    public DialogueSO donutsPrompt;
    public DialogueSO epilogue;
    [SerializeField] private DialogueManager manager;
    private DisplayQuests displayer;

    public Task returnIngredients;
    public Task finishedDonuts;

    public bool[] items = { false, false, false };

    void Start()
    {
        manager = FindObjectOfType<DialogueManager>();
        displayer = FindObjectOfType<DisplayQuests>();

        if (levelTwoState.ingreadientsFound && levelTwoState.donutsCreated)
        {
            runEpilogueDialogue();
            displayer.curTask = finishedDonuts;
            displayer.displayCurrentTask();

        } else if (levelTwoState.ingreadientsFound)
        {
            runMinigame3Guide();
            displayer.curTask = returnIngredients;
            displayer.displayCurrentTask();
        }
        else
        {
            runMinigame2Guide();
        }
    }

    public bool itemActive(int idx)
    {
        if (idx == 0)
        {
            return levelTwoState.donutsCreated && !items[idx];
        }
        else
        {
            return levelTwoState.donutsCreated && items[idx - 1] && !items[idx];
        }
    }

    public void getItem(int idx)
    {
        items[idx] = true;
    }


    private void runMinigame2Guide()
    {
        
        this.manager.StartDialogue(ingredientsPrompt);
    }

    private void runMinigame3Guide()
    {
        this.manager.StartDialogue(donutsPrompt);
    }

    private void runEpilogueDialogue()
    {
        this.manager.StartDialogue(epilogue);
    }
}
