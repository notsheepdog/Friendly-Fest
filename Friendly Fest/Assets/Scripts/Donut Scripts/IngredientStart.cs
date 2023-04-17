using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientStart : MonoBehaviour
{
    private static bool ingredientsVisited = false;
    public DialogueSO introDialogue;

    // Start is called before the first frame update
    void Start()
    {
        if (!ingredientsVisited)
        {
            DialogueManager dm = GameObject.FindObjectOfType<DialogueManager>();
            dm.StartDialogue(introDialogue);
            dm.DisplayNextSentence();
            ingredientsVisited = true;
        }
    }
}
