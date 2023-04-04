using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{

    public KeyCode interaction;
    public GameObject interactText;
    public DialogueSO _dialogue;
    [SerializeField] private DialogueManager _dialogueManager;

    private bool _playerInRange;

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


    public void TriggerDialogue()
    {
        if (this._playerInRange)
        {
            this._playerInRange = false;
            this._dialogueManager.StartDialogue(this._dialogue);
            this._dialogueManager.SetTrigger(this);

            // quick fix (can be changed later) to update workie animations
            try
            {
                if(transform.parent != null)
                {
                    transform.parent.gameObject.SendMessage("DialogueEnter");
                }
            }
            catch { }
        }

    }

    public void EndDialogue()
    {
        // quick fix (can be changed later) to update workie animations
        try
        {
            if(transform.parent != null)
            {
                transform.parent.gameObject.SendMessage("DialogueExit");
            }
        }
        catch { }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("interaction zone inside");
            this.interactText.SetActive(true);
            this._playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Interaction zone outside");
            this.interactText.SetActive(false);
            this._playerInRange = false;
        }
    }

}

