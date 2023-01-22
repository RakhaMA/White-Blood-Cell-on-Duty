using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public string targetScene;

    public void loadScene()
    {
        SceneManager.LoadScene(targetScene);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
