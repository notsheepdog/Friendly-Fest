using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2StateManager : MonoBehaviour
{
    [SerializeField] private Level2SO levelTwoState;
    public DialogueSO ingredientsPrompt;
    public DialogueSO donutsPrompt;
    public DialogueSO tradingPrompt;
    public DialogueSO epilogue;
    [SerializeField] private DialogueManager manager;
    private DisplayQuests displayer;

    public Task returnIngredients;
    public Task finishedDonuts;
    public Task tradeItems;

    public bool[] items = { false, false, false };

    void Start()
    {
        manager = FindObjectOfType<DialogueManager>();
        displayer = FindObjectOfType<DisplayQuests>();

        if (levelTwoState.ingreadientsFound && levelTwoState.donutsCreated) // start the trading minigame
        {
            runMinigame4Guide();
            displayer.curTask = tradeItems;
            displayer.displayCurrentTask();
        } else if (levelTwoState.ingreadientsFound) // prompt for the donuts
        {
            runMinigame3Guide();
            displayer.curTask = returnIngredients;
            displayer.displayCurrentTask();
        }
        else if (levelTwoState.itemsTraded) // I don't think this should ever happen but i'm leaving it in
        {
            runEpilogueDialogue();
            displayer.curTask = finishedDonuts;
            displayer.displayCurrentTask();
        }
        else
        {
            runMinigame2Guide(); // prompt for the ingredients
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
            runEpilogueDialogue();
            displayer.curTask = finishedDonuts;
            displayer.displayCurrentTask();
        }
    }


    private void runMinigame2Guide()
    {
        
        this.manager.StartDialogue(ingredientsPrompt);
    }

    private void runMinigame3Guide()
    {
        this.manager.StartDialogue(donutsPrompt);
    }

    private void runMinigame4Guide()
    {
        this.manager.StartDialogue(tradingPrompt);
    }

    private void runEpilogueDialogue()
    {
        this.manager.StartDialogue(epilogue);
    }
}
