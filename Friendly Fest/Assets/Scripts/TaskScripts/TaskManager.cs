using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskManager : MonoBehaviour
{
    public static bool initialized = false;
    public static Dictionary<string, Task> cur_tasks;
    [SerializeField] private Task starting_task;
    [SerializeField] private TextMeshProUGUI task_display;

    public void Start()
    {
        cur_tasks = new Dictionary<string, Task>();
        if (!initialized)
        {
            this.AddTask(starting_task);
            initialized = true;
        }
    }

    // adds a given task to our dictionary and then re-renders the list
    public void AddTask(Task t)
    {
        cur_tasks.Add(t.objective, t);
        this.RenderTasks();
    }

    // goes through the list and correctly renders tasks
    public void RenderTasks()
    {
        string task_acc = "";

        foreach (Task cur in cur_tasks.Values)
        {

            if (cur.completed)
            {
                task_acc += "<s>" + cur.objective + "</s>\n";
            }
            else
            {
                task_acc += cur.objective + "\n";
            }
        }

        this.task_display.text = task_acc;

    }

    // clears ths list and re renders on the UI
    public void ClearTasks()
    {
        cur_tasks.Clear();
        this.RenderTasks();
    }

    // remove a given task object from the map of tasks
    public void RemoveTask(Task t)
    {
        cur_tasks.Remove(t.objective);
        this.RenderTasks();
    }

    // mark a given task as completed by accessing it from the hashmap
    public void CompleteTask(Task t)
    {
        cur_tasks[t.objective].completed = true;
    }

}
