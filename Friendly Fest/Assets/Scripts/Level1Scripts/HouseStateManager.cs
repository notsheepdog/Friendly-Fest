using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseStateManager : MonoBehaviour
{
    public HouseState state;
    public Level1 oneState;
    public Level2SO twoState;
    public GameObject minMother;

    public DialogueSO beginning;
    public Task beginningTask;

    public DialogueSO paper_signed;
    public Task fetchBanner;

    public DialogueSO collected_items;
    public Task collectIngredients;

    public DialogueSO donutsCreated;
    public Task createDonuts;

    public Task enjoy;

    DialogueTrigger motherDialogue;
    TaskManager displayer;

    public LevelManager exitPoint;
    public GameObject donuts;

    // Start is called before the first frame update
    void Start()
    {
        motherDialogue = minMother.GetComponentInChildren<DialogueTrigger>();

        displayer = GameObject.FindGameObjectWithTag("Objective")
                    .GetComponent<TaskManager>();

    }

    // Update is called once per frame
    void Update()
    {
        state.paperReceived = oneState.paperSigned;
        state.ingredientsCollected = twoState.ingreadientsFound;
        state.donutsMade = twoState.donutsCreated;

        if (state.paperReceived && !state.ingredientsCollected && !state.donutsMade)
        {
            motherDialogue._dialogue = paper_signed;
            //displayer.ClearTasks();
            exitPoint.nextScene = 4;
            donuts.SetActive(true);
        } else if (state.ingredientsCollected && !state.donutsMade)
        {
            motherDialogue._dialogue = collected_items;
            donuts.GetComponent<LevelManager>().nextScene = 6;
        } else if (state.donutsMade)
        {
            motherDialogue._dialogue = donutsCreated;
        }
        else
        {
            motherDialogue._dialogue = beginning;
            exitPoint.nextScene = 4;
            donuts.SetActive(false);
        }
    }
}
