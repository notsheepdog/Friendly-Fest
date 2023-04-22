using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentSaveData : MonoBehaviour
{
    public static Task[] staticTasks;
    public static HouseState staticHouseState;
    public static Level1 staticLevel1State;
    public static Level2SO staticLevel2State;
    public static int sceneIdx;

    public Task[] tasks;
    public HouseState houseState;
    public Level1 level1State;
    public Level2SO level2State;

    void Start()
    {
        staticTasks = tasks;
        staticHouseState = houseState;
        staticLevel1State = level1State;
        staticLevel2State = level2State;
        Object.DontDestroyOnLoad(gameObject);
    }

    public static void NewGame()
    {
        for(int i = 0; i < staticTasks.Length; i++)
        {
            staticTasks[i].completed = false;
            PlayerPrefs.SetInt("taskListed" + i, 0);
        }

        // static public bools
        LobbyStateHandler.visited = false;
        OfficeMazeManager.visited = false;
        DialoguePlayOnStart.signingVisited = false;

        // house state SO
        staticHouseState.dadTalked = false;
        staticHouseState.paperReceived = false;
        staticHouseState.ingredientsCollected = false;
        staticHouseState.donutsMade = false;

        // level 1 SO
        staticLevel1State.paperSigned = false;

        // level 2 SO
        staticLevel2State.papersReturned = false;
        staticLevel2State.ingreadientsFound = false;
        staticLevel2State.ingredientsReturned = false;
        staticLevel2State.donutsCreated = false;
        staticLevel2State.itemsTraded = false;

        UpdateTaskData();
    }

    public static void ContinueGame()
    {
        for (int i = 0; i < staticTasks.Length; i++)
        {
            staticTasks[i].completed = PlayerPrefs.GetInt("taskCompleted" + i) == 1;
        }
        TaskManager.loadFromData = true;

        // static public bools
        LobbyStateHandler.visited = PlayerPrefs.GetInt("lobbyEntered") == 1;
        OfficeMazeManager.visited = PlayerPrefs.GetInt("mazeEntered") == 1;
        DialoguePlayOnStart.signingVisited = PlayerPrefs.GetInt("signedDocument") == 1;

        // house state SO
        staticHouseState.dadTalked = PlayerPrefs.GetInt("dadTalked") == 1;
        staticHouseState.paperReceived = PlayerPrefs.GetInt("paperReceived") == 1;
        staticHouseState.ingredientsCollected = PlayerPrefs.GetInt("ingredientsCollected") == 1;
        staticHouseState.donutsMade = PlayerPrefs.GetInt("donutsMade") == 1;

        // level 1 SO
        staticLevel1State.paperSigned = PlayerPrefs.GetInt("papersSigned") == 1;

        // level 2 SO
        staticLevel2State.papersReturned = PlayerPrefs.GetInt("papersReturned") == 1;
        staticLevel2State.ingreadientsFound = PlayerPrefs.GetInt("ingreadientsFound") == 1;
        staticLevel2State.ingredientsReturned = PlayerPrefs.GetInt("ingredientsReturned") == 1;
        staticLevel2State.donutsCreated = PlayerPrefs.GetInt("donutsCreated") == 1;
        staticLevel2State.itemsTraded = PlayerPrefs.GetInt("itemsTraded") == 1;
    }

    public static void UpdateTaskData()
    {
        for (int i = 0; i < staticTasks.Length; i++)
        {
            PlayerPrefs.SetInt("taskCompleted" + i, staticTasks[i].completed ? 1 : 0);
            if (TaskManager.cur_tasks != null)
            {
                PlayerPrefs.SetInt("taskListed" + i, TaskManager.cur_tasks.ContainsValue(staticTasks[i]) ? 1 : 0);
            }
        }
    }

    public static void UpdateSceneData()
    {
        PlayerPrefs.SetInt("sceneIndex", SceneManager.GetActiveScene().buildIndex);

        // public static bools
        PlayerPrefs.SetInt("lobbyEntered", LobbyStateHandler.visited ? 1 : 0);
        PlayerPrefs.SetInt("mazeEntered", OfficeMazeManager.visited ? 1 : 0);
        PlayerPrefs.SetInt("signedDocument", DialoguePlayOnStart.signingVisited ? 1 : 0);

        // house state SO
        PlayerPrefs.SetInt("dadTalked", staticHouseState.dadTalked ? 1 : 0);
        PlayerPrefs.SetInt("paperReceived", staticHouseState.paperReceived ? 1 : 0);
        PlayerPrefs.SetInt("ingredientsCollected", staticHouseState.ingredientsCollected ? 1 : 0);
        PlayerPrefs.SetInt("donutsMade", staticHouseState.donutsMade ? 1 : 0);

        // level 1 SO
        PlayerPrefs.SetInt("papersSigned", staticLevel1State.paperSigned ? 1 : 0);

        // level 2 SO
        PlayerPrefs.SetInt("papersReturned", staticLevel2State.papersReturned ? 1 : 0);
        PlayerPrefs.SetInt("ingreadientsFound", staticLevel2State.ingreadientsFound ? 1 : 0);
        PlayerPrefs.SetInt("ingredientsReturned", staticLevel2State.ingredientsReturned ? 1 : 0);
        PlayerPrefs.SetInt("donutsCreated", staticLevel2State.donutsCreated ? 1 : 0);
        PlayerPrefs.SetInt("itemsTraded", staticLevel2State.itemsTraded ? 1 : 0);
    }

    public static int TasksCompleted()
    {
        int tasksCompleted = 0;
        for (int i = 0; i < staticTasks.Length; i++)
        {
            tasksCompleted += PlayerPrefs.GetInt("taskCompleted" + i);
        }
        return tasksCompleted;
    }

    public static List<Task> GetListedTasks()
    {
        List<Task> tasks = new List<Task>();
        for (int i = 0; i < staticTasks.Length; i++)
        {
            if (PlayerPrefs.GetInt("taskListed" + i) == 1)
            {
                tasks.Add(staticTasks[i]);
            }
        }
        return tasks;
    }
}
