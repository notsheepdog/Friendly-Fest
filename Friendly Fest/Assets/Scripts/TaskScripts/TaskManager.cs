using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskManager : MonoBehaviour
{
    public static bool initialized = false;
    public static bool loadFromData = false;
    public static Dictionary<string, Task> cur_tasks;
    [SerializeField] private Task starting_task;
    [SerializeField] private TextMeshProUGUI task_display;

    public void Start()
    {
        if (!initialized)
        {
            if (loadFromData)
            {
                cur_tasks = new Dictionary<string, Task>();
                List<Task> tasks = PersistentSaveData.GetListedTasks();
                for (int i = 0; i < tasks.Count; i++)
                {
                    this.AddTask(tasks[i]);
                }
            }
            else
            {
                cur_tasks = new Dictionary<string, Task>();
                this.AddTask(starting_task);
                initialized = true;
            } 
        }
    }

    // adds a given task to our dictionary and then re-renders the list
    public void AddTask(Task t)
    {
        if (!cur_tasks.ContainsValue(t))
        {
            cur_tasks.Add(t.objective, t);
            this.RenderTasks();
            UpdatePersistentData();
        }
    }

    // goes through the list and correctly renders tasks
    public void RenderTasks()
    {
        string task_acc = "";

        foreach (Task cur in cur_tasks.Values)
        {

            if (cur.completed)
            {
                Debug.Log("printing completed task");
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
        UpdatePersistentData();
    }

    // remove a given task object from the map of tasks
    public void RemoveTask(Task t)
    {
        cur_tasks.Remove(t.objective);
        this.RenderTasks();
        UpdatePersistentData();
    }

    // mark a given task as completed by accessing it from the hashmap
    public void CompleteTask(Task t)
    {
        cur_tasks[t.objective].completed = true;
        this.RenderTasks();
        UpdatePersistentData();
    }

    private void UpdatePersistentData()
    {
        if (GameObject.FindGameObjectWithTag("saveData") != null)
        {
            PersistentSaveData.UpdateTaskData();
        }
    }

}
