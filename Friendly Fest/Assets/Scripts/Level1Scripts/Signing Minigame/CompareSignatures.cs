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

    public int Compare()
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

        //calculates score based on:
        // (player's pixels that overlap correct pixels)
        // out of
        // (overlapping pixels + player's added pixels that dont overlap + correct signature pixels that the player didnt add)
        float hit = 0;
        float miss = 0;
        for (var i = 0; i < playerComparisonOutput.Length; i++)
        {
            if (playerComparisonOutput[i] == Color.black || outputComparison[i] == Color.black)
            {
                if (playerComparisonOutput[i].r == outputComparison[i].r)
                {
                    hit++;
                }
                else
                {
                    miss++;
                }
            }

        }

        return Mathf.CeilToInt(hit / (hit + miss) * 100);
    }
}
