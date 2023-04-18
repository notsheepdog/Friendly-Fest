using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static bool dialogueOn;

    public Queue<string> sentences;
    private List<Task> tasks_to_add;
    private List<Task> tasks_to_mark;
    private string _name;

    public Text _dialogue_text;
    public Text _name_text;

    public GameObject _textBox;

    public KeyCode interact;

    private TaskManager tm;


    // Start is called before the first frame update
    void Awake()
    {
        this.sentences = new Queue<string>();
        this.tm = FindObjectOfType<TaskManager>();
        this.tasks_to_add = new List<Task>();
        this.tasks_to_mark = new List<Task>();
        this._name = "";

    }

    void Update()
    {
        if (Input.GetKeyDown(interact) && dialogueOn)
        {
            this.DisplayNextSentence();
        }
    }


    public void StartDialogue(DialogueSO dialogue)
    {
        this.sentences.Clear();
        dialogueOn = true;
        foreach (var sentence in dialogue.Sentences)
        {
            this.sentences.Enqueue(sentence);
        }

        foreach (Task task in dialogue.tasks)
        {
            this.tasks_to_add.Add(task);
        }

        foreach(Task task in dialogue.mark_complete)
        {
            this.tasks_to_mark.Add(task);
        }

        this._name = dialogue.Name;

        this._textBox.SetActive(true);
    }

    public void DisplayNextSentence()
    {

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
        dialogueOn = false;
        this._textBox.SetActive(false);
        foreach(Task t in this.tasks_to_add)
        {
            this.tm.AddTask(t);
        }

        foreach(Task t in this.tasks_to_mark)
        {
            this.tm.CompleteTask(t);
        }
    }
}
