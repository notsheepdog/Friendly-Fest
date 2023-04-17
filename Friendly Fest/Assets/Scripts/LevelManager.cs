using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int nextScene;
    public GameObject exclamation;
    public KeyCode interaction;
    private bool inRange;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("saveData") != null)
        {
            PersistentSaveData.UpdateTaskData();
            PersistentSaveData.UpdateSceneData();
        }
        
        this.exclamation.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(interaction))
            {
                MoveToNextScene();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        this.exclamation.SetActive(true);
        inRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        this.exclamation.SetActive(false);
        inRange = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        MoveToNextScene();
    }

    public void MoveToNextScene()
    {
        Debug.Log(nextScene);
        SceneManager.LoadScene(nextScene);
    }
}
