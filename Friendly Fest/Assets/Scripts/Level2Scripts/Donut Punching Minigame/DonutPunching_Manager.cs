using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DonutPunching_Manager : MonoBehaviour
{
    public HolePunching holePunchingController;
    public Transform levelMarkerParent;
    public Transform donutsParent;
    public Level2SO levelTwoState;

    private Transform[] donuts;
    private Image[] levelMarkers;
    private Color levelMarkerDefaultColor;
    private Color levelMarkerCurrentColor;

    private int currentLevel = 0;
    
    void Start()
    {
        if (donutsParent.childCount != levelMarkerParent.childCount)
        {
            Debug.LogError("Unequal number of donuts and level markers");
        }

        levelMarkers = new Image[levelMarkerParent.childCount];
        donuts = new Transform[donutsParent.childCount];
        for (int i = 0; i < levelMarkers.Length; i++)
        {
            levelMarkers[i] = levelMarkerParent.GetChild(i).GetComponent<Image>();
            donuts[i] = donutsParent.GetChild(i);
        }

        levelMarkerDefaultColor = levelMarkers[0].color;

        levelMarkers[currentLevel].color =
        levelMarkerCurrentColor = new Color(levelMarkerDefaultColor.r, levelMarkerDefaultColor.g,
                                            levelMarkerDefaultColor.b, 1);
    }

    public void failLevel()
    {
        levelMarkers[currentLevel].color = Color.red;
        currentLevel = 0;
        Invoke("SetLevel", 0.5f);
    }

    public void nextLevel()
    {
        levelMarkers[currentLevel].color = Color.green;
        currentLevel++;
        if (currentLevel == levelMarkers.Length)
        {
            // successfully finish minigame
            levelTwoState.donutsCreated = true;
        }
        else
        {
            Invoke("SetLevel", 0.5f);
        }
    }

    private void SetLevel()
    {
        for (int i = 0; i < levelMarkers.Length; i++)
        {
            donuts[i].gameObject.SetActive(false);
            if (i >= currentLevel + 1)
            {
                levelMarkers[i].color = levelMarkerDefaultColor;
            }
        }

        levelMarkers[currentLevel].color = levelMarkerCurrentColor;
        donuts[currentLevel].gameObject.SetActive(true);

        holePunchingController.resetHolePunching(donuts[currentLevel]);
    }
}
