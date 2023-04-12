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
            if (levelManager.itemActive(item))
            {
                this._dialogueManager.StartDialogue(this._itemDialogue);
                levelManager.getItem(item);
            }
            else
            {
                this._dialogueManager.StartDialogue(this._dialogue);
            }
            this._dialogueManager.SetTrigger(this);

            // quick fix (can be changed later) to update workie animations
            if (transform.parent != null && transform.parent.GetComponent<NPCState>() != null)
            {
                transform.parent.GetComponent<NPCState>().DialogueEnter();
            }
        }
    }
}
