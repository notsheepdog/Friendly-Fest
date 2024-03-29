﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{

    public KeyCode interaction;
    public DialogueSO _dialogue;
    [SerializeField] protected DialogueManager _dialogueManager;

    protected bool _playerInRange;

    void Start()
    {
        _dialogueManager = FindObjectOfType<DialogueManager>();
    }

    public void Update()
    {
        if (this._playerInRange)
        {
            if (Input.GetKeyDown(interaction))
            {
                this.TriggerDialogue();
            }
        }
    }


    public virtual void TriggerDialogue()
    {
        if (this._playerInRange)
        {
            this._playerInRange = false;
            if(this._dialogueManager.sentences.Count == 0)
            {
                Debug.Log("starting a new dialogue");
                this._dialogueManager.StartDialogue(this._dialogue);
            }

        }
    }


    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("interaction zone inside");
            this._playerInRange = true;
        }
    }

    protected void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Interaction zone outside");
            this._playerInRange = false;
        }
    }

}

