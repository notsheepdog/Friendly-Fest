using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayQuests : MonoBehaviour
{
    public Task curTask;
    public Text objectiveText;

    void Start()
    {
        displayCurrentTask();
    }

    public void displayCurrentTask()
    {
        this.objectiveText.text = "Goal: " + this.curTask.objective;
    }
}
