using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueItemTrigger : DialogueTrigger
{
    public DialogueSO _itemDialogue;
    public int item;

    [SerializeField] private Level2StateManager levelManager;

    void Start()
    {
        _dialogueManager = FindObjectOfType<DialogueManager>();
        levelManager = FindObjectOfType<Level2StateManager>();
    }

    public override void TriggerDialogue()
    {
        if (this._playerInRange)
        {
            this._playerInRange = false;
            if (this._dialogueManager.sentences.Count == 0)
            {
                Debug.Log("starting a new dialogue");
                if (levelManager.itemActive(item))
                {
                    this._dialogueManager.StartDialogue(this._itemDialogue);
                    levelManager.getItem(item);
                }
                else
                {
                    this._dialogueManager.StartDialogue(this._dialogue);
                }
            }
        }
    }
}
