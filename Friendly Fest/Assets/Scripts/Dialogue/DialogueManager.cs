using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    private string _name;
    public Text _dialogue_text;
    public Text _name_text;
    public GameObject _textBox;
    public AudioClip _dialogueSFX;
    public KeyCode interact;

    private DialogueTrigger currentTrigger;


    // Start is called before the first frame update
    void Start()
    {
        this.sentences = new Queue<string>();
        this._name = "";

    }
    
    // used if the gameObject that triggered the dialogue needs to know when the dialogue ends
    public void SetTrigger(DialogueTrigger trigger)
    {
        currentTrigger = trigger;
    }


    public void StartDialogue(DialogueSO dialogue)
    {
        Debug.Log("starting");
        Debug.Log(dialogue.name);

        this.sentences.Clear();
        this._textBox.SetActive(true);
        foreach (var sentence in dialogue.Sentences)
        {
            this.sentences.Enqueue(sentence);
        }

        this._name = dialogue.Name;
        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        AudioSource.PlayClipAtPoint(_dialogueSFX, Camera.main.transform.position);

        Debug.Log("next sentence");
        if (sentences.Count == 0)
        {
            Debug.Log("ending the dialogue");
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        this._dialogue_text.text = sentence;
        this._name_text.text = this._name;
    }

    public void EndDialogue()
    {
        if (currentTrigger != null)
        {
            currentTrigger.EndDialogue();
            currentTrigger = null;
        }
        this._textBox.SetActive(false);
    }
}
