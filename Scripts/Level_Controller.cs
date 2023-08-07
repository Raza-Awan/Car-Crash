using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Controller : MonoBehaviour
{
    int activeSceneIndex;
    int nextSceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 1;
        }
    }

    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Next()
    {
        activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        nextSceneIndex = activeSceneIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
    public void Restart()
    {
        activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneIndex);
    }
}
