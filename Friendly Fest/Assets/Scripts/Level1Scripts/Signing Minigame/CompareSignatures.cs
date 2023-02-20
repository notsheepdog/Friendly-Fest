using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompareSignatures : MonoBehaviour
{
    public Camera playerSigMonitor;
    public RenderTexture playerSig;
    public Camera comparisonSigMonitor;
    public RenderTexture comparisonSig;

    private Color32[] playerComparisonOutput;
    private Color32[] outputComparison;

    void Start()
    {
        //makes an array of 125 000 pixels to represent the original signature
        Texture2D tex = new Texture2D(250, 125, TextureFormat.RGB24, true);
        tex.wrapMode = TextureWrapMode.Clamp;
        tex.filterMode = FilterMode.Point;

        comparisonSigMonitor.targetTexture = comparisonSig;
        comparisonSigMonitor.Render();

        RenderTexture.active = comparisonSig;
        tex.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        RenderTexture.active = null;

        tex.Apply();

        outputComparison = tex.GetPixels32();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Compare();
        }
    }

    void Compare()
    {
        //makes an array of 125 000 pixels to represent the user's signature
        Texture2D tex = new Texture2D(250, 125, TextureFormat.RGB24, true);
        tex.wrapMode = TextureWrapMode.Clamp;
        tex.filterMode = FilterMode.Point;

        playerSigMonitor.targetTexture = playerSig;
        playerSigMonitor.Render();

        RenderTexture.active = playerSig;
        tex.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        RenderTexture.active = null;

        tex.Apply();

        playerComparisonOutput = tex.GetPixels32();

        Debug.Log("player length: " + playerComparisonOutput.Length);
        Debug.Log("comp length: " + outputComparison.Length);

        //checks on each pixel if the user's signature's pixel's color matches that of the original signature
        int score = 0;
        for (var i = 0; i < playerComparisonOutput.Length; i++)
        {
            if (playerComparisonOutput[i].r == outputComparison[i].r)
            {
                score++;
            }

        }

        Debug.Log(Mathf.CeilToInt((score / (float) playerComparisonOutput.Length) * 100) + "%");
        
    }
}
