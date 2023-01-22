using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider loadingBar;
    public void LoadScene(int level_Index)
    {
       StartCoroutine(WaitBeforeShow());
       StartCoroutine(LoadSceneAsynchronously(level_Index));
       //coroutine buat pdate loading ketika scene berkalan
    }  
    IEnumerator WaitBeforeShow()
    {
        yield return new WaitForSeconds(30);
    } 

    IEnumerator LoadSceneAsynchronously(int level_Index)
    {
        AsyncOperation operation =  SceneManager.LoadSceneAsync(level_Index);
        loadingScreen.SetActive(true);
        
        while (!operation.isDone)
        {   
            loadingBar.value = operation.progress;
            yield return null;
        }
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
