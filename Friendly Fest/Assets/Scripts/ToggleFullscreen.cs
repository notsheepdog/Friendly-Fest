using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToggleFullscreen : MonoBehaviour
{
    public TextMeshProUGUI button;
    public string clicked = "ON";
    public string unclicked = "OFF";

    private void Start()
    {
        Screen.fullScreen = false;
        button.text = unclicked;
    }

    public void Toggle()
    {
        Screen.fullScreen = !Screen.fullScreen;

        if (Screen.fullScreen)
        {
            button.text = clicked;
        }
        else
        {
            button.text = unclicked;
        }
    }
}
