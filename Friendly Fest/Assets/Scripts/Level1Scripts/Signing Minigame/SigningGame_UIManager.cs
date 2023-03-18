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
    public AudioClip winSFX;
    public AudioClip retrySFX;

    // for TMPro
    public TextMeshProUGUI results;

    private CompareSignatures sigCompare;
    [SerializeField]private Level1 level1State;

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
            AudioSource.PlayClipAtPoint(winSFX, Camera.main.transform.position);
            results.text = "Wow that looks spot on!";

            level1State.paperSigned = true;

            for (int i = drawingBoard.childCount; i > 0; i--)
            {
                LineRenderer lr = drawingBoard.GetChild(i - 1).GetComponent<LineRenderer>();
                lr.startColor = Color.green;
                lr.endColor = Color.green;
            }

            StartCoroutine(displayAndTransition());

        }
        else
        {
            AudioSource.PlayClipAtPoint(retrySFX, Camera.main.transform.position);
            results.text = "let's give that another try!";

            level1State.paperSigned = false;

            for (int i = drawingBoard.childCount; i > 0; i--)
            {
                LineRenderer lr = drawingBoard.GetChild(i - 1).GetComponent<LineRenderer>();
                lr.startColor = Color.red;
                lr.endColor = Color.red;
            }

            Invoke("Clear", 0.5f);
        }
    }

    private IEnumerator displayAndTransition()
    {
        Debug.Log("displaying win state");
        yield return new WaitForSeconds(2.5f);
        Debug.Log("Transitioning to next scene");
        FindObjectOfType<LevelManager>().MoveToNextScene();
    }
}
