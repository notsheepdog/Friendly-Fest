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

    void Start()
    {
        manager = FindObjectOfType<DialogueManager>();
        if (levelTwoState.ingreadientsFound && levelTwoState.donutsCreated)
        {
            runEpilogueDialogue();
            FindObjectOfType<LevelManager>().nextScene = 5;
        } else if (levelTwoState.ingreadientsFound)
        {
            runMinigame3Guide();
            FindObjectOfType<LevelManager>().nextScene = 4;
        }
        else
        {
            runMinigame2Guide();
            FindObjectOfType<LevelManager>().gameObject.SetActive(false);
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

    private void runEpilogueDialogue()
    {
        this.manager.StartDialogue(epilogue);
    }
}
