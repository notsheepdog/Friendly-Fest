using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{

    public KeyCode interaction;
    public GameObject interactText;
    [SerializeField] private DialogueSO _dialogue;
    [SerializeField] private DialogueManager _dialogueManager;

    private bool _playerInRange;

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
        }

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

