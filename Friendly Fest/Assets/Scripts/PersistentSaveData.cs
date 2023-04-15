using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentSaveData : MonoBehaviour
{
    public static Task[] staticTasks;
    public static int sceneIdx;

    public Task[] tasks;

    void Start()
    {
        staticTasks = tasks;
        Object.DontDestroyOnLoad(gameObject);
    }

    public static void NewGame()
    {
        for(int i = 0; i < staticTasks.Length; i++)
        {
            staticTasks[i].completed = false;
        }

        UpdateTaskData();
    }

    public static void ContinueGame()
    {
        for (int i = 0; i < staticTasks.Length; i++)
        {
            staticTasks[i].completed = PlayerPrefs.GetInt("task" + i) == 1;
        }
    }

    public static void UpdateTaskData()
    {
        for (int i = 0; i < staticTasks.Length; i++)
        {
            PlayerPrefs.SetInt("task" + i, staticTasks[i].completed ? 1 : 0);
        }
    }

    public static void UpdateSceneData()
    {
        PlayerPrefs.SetInt("sceneIndex", SceneManager.GetActiveScene().buildIndex);
    }

    public static int TasksCompleted()
    {
        int tasksCompleted = 0;
        for (int i = 0; i < staticTasks.Length; i++)
        {
            tasksCompleted += PlayerPrefs.GetInt("task" + i);
        }
        return tasksCompleted;
    }
}
