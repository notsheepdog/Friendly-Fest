using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SigningGame_UIManager : MonoBehaviour
{
    public Transform drawingBoard;
    public Button clear;
    public Button submit;

    // for TMPro
    public TextMeshProUGUI results;

    private CompareSignatures sigCompare;

    void Start()
    {
        sigCompare = gameObject.GetComponent<CompareSignatures>();
    }

    public void Clear()
    {
        for (int i = drawingBoard.childCount; i > 0; i--)
        {
            Destroy(drawingBoard.GetChild(i - 1).gameObject);
        }
    }

    public void Submit()
    {
        int score = sigCompare.Compare();

        if (score >= 18)
        {
            results.text = "great signature! end of prototype.";

            for (int i = drawingBoard.childCount; i > 0; i--)
            {
                LineRenderer lr = drawingBoard.GetChild(i - 1).GetComponent<LineRenderer>();
                lr.startColor = Color.green;
                lr.endColor = Color.green;
            }
        }
        else
        {
            results.text = "let's give that another try!";

            for (int i = drawingBoard.childCount; i > 0; i--)
            {
                LineRenderer lr = drawingBoard.GetChild(i - 1).GetComponent<LineRenderer>();
                lr.startColor = Color.red;
                lr.endColor = Color.red;
            }

            Invoke("Clear", 0.5f);
        }
    }
}
