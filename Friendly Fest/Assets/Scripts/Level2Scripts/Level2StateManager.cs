using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2StateManager : MonoBehaviour
{
    [SerializeField] private Level2SO levelTwoState;
    [SerializeField] private Level1 levelOneState;
    public DialogueSO toOfficePrompt;
    public DialogueSO ingredientsPrompt;
    public DialogueSO donutsPrompt;
    public DialogueSO tradingPrompt;
    public DialogueSO epilogue;
    [SerializeField] private DialogueManager manager;
    private TaskManager displayer;

    public Task returnIngredients;
    public Task exploreFestival;
    public Task tradeItems;

    public bool[] items = { false, false, false };

    void Start()
    {
        manager = FindObjectOfType<DialogueManager>();
        displayer = FindObjectOfType<TaskManager>();
        displayer.RenderTasks();

        if (levelTwoState.ingreadientsFound && levelTwoState.donutsCreated) // start the trading minigame
        {
            runMinigame4Guide();
        } else if (levelTwoState.ingreadientsFound) // prompt for the donuts
        {
            runMinigame3Guide();
        }
        else if (levelTwoState.itemsTraded) // I don't think this should ever happen but i'm leaving it in
        {
            runEpilogueDialogue();
        }
        else if (levelOneState.paperSigned)
        {
            runMinigame2Guide(); // prompt for the ingredients
        }
        else
        {
            runToOfficeDialogue();
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
        if (items[0] && items[1] && items[2])
        {
            levelTwoState.itemsTraded = true;
//            runEpilogueDialogue();
            displayer.AddTask(exploreFestival);
        }
    }

    private void runToOfficeDialogue()
    {
        this.manager.StartDialogue(this.toOfficePrompt);
        this.manager.DisplayNextSentence();
    }


    private void runMinigame2Guide()
    {
        
        this.manager.StartDialogue(ingredientsPrompt);
        this.manager.DisplayNextSentence();
    }

    private void runMinigame3Guide()
    {
        this.manager.StartDialogue(donutsPrompt);
        this.manager.DisplayNextSentence();
    }

    private void runMinigame4Guide()
    {
        this.manager.StartDialogue(tradingPrompt);
        this.manager.DisplayNextSentence();
    }

    private void runEpilogueDialogue()
    {
        this.manager.StartDialogue(epilogue);
        this.manager.DisplayNextSentence();
    }
}
