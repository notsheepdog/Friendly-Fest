using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int nextScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        MoveToNextScene();
    }

    private void OnCollisionEnter(Collision collision)
    {
        MoveToNextScene();
    }

    public void MoveToNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
