using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public TextMeshProUGUI tasksCompleted;

    private void Start()
    {
        Invoke("SetTasksCompleted", 0);
    }

    private void SetTasksCompleted()
    {
        tasksCompleted.text = "Tasks Completed: " + PersistentSaveData.TasksCompleted()
            + " / " + PersistentSaveData.staticTasks.Length;
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(0);
        PersistentSaveData.NewGame();
    }

    public void ContinueGame()
    {
        PersistentSaveData.ContinueGame();
        SceneManager.LoadScene(PlayerPrefs.GetInt("sceneIndex"));
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
