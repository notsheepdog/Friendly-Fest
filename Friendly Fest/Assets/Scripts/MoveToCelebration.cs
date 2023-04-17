using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToCelebration : MonoBehaviour
{
    public Level2SO level2;
    public int celebrationScene;

    // Update is called once per frame
    void Update()
    {
        if (level2.itemsTraded)
        {
            SceneManager.LoadScene(celebrationScene);
        }
    }
}
