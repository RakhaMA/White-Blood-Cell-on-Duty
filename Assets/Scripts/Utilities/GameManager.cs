using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // public static GameObject loadingScreen;
    // public static Slider loadingBar;
    // public static Text LoadingProgressText;
    
    public static GameObject player;
    public static GameObject GameOverPanel;
    public static GameObject finishPanel;
    public static GameObject pausePanel;
    public bool isBossLevel;
    public AudioManager audioManager;

    public List<int> objectives;
    public int objectivesCount;
    private int thrombocyteCollected;

    private static int objectivesCompleted;
    private static int virusKillCount;
    private static int thrombosisCreated;
    private int virusCount;
    private int thrombosisSpotCount;
    public bool isLevelCompleted;

    [Header("UI")]
    public Text objective1Text;
    public Text objective2Text;
    public Text thrombocyteText;

    private Vector3 checkpointPosition;
    private static bool isPaused = false;
    

    private void Awake() {
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    private void Start() {
        virusCount = FindObjectsOfType<BasicVirus>().Length;
        thrombosisSpotCount = FindObjectsOfType<Thrombosis>().Length;
        objectives.Add(virusCount);
        objectives.Add(thrombosisSpotCount);
        objectivesCount = objectives.Count;
        checkpointPosition = player.transform.position;

        objective1Text = GameObject.Find("Objective1Text").GetComponent<Text>();
        if (!isBossLevel) {
            objective2Text = GameObject.Find("Objective2Text").GetComponent<Text>();
            thrombocyteText = GameObject.Find("ThrombocyteText").GetComponent<Text>();
        }
        
        finishPanel = GameObject.Find("FinishPanel");
        GameOverPanel = GameObject.Find("GameOverPanel");
        pausePanel = GameObject.Find("PausePanel");
        // loadingScreen = GameObject.Find("LoadingScreen");
        // loadingBar = GameObject.Find("LoadingSlider").GetComponent<Slider>();
        // LoadingProgressText = loadingScreen.transform.Find("LoadingProgressText").GetComponent<Text>();
        
        finishPanel.SetActive(false);
        GameOverPanel.SetActive(false);
        pausePanel.SetActive(false);

        audioManager.PlayMusic();
        // loadingScreen.SetActive(false);

    }

    private void Update() {
        if (virusKillCount >= virusCount && thrombosisCreated >= thrombosisSpotCount) {
            isLevelCompleted = true;
        }

        if (objective1Text) {
            objective1Text.text = "Kill virus (" + virusKillCount + "/" + virusCount + ")";
        }

        if (objective2Text) {
            objective2Text.text = "Deploy Thrombosis (" + thrombosisCreated + "/" + thrombosisSpotCount + ")";
        }
        
        if (thrombocyteText) {
            thrombocyteCollected = player.GetComponentInChildren<ThrombocyteCollector>().thrombocytes.Count;
            thrombocyteText.text = "x " + thrombocyteCollected + "/" + FindObjectOfType<Thrombosis>().requiredThrombocyteCount;
        }

        Debug.Log("level completed: " + isLevelCompleted);

        if (Input.GetKeyDown(KeyCode.Escape)) {
            isPaused = !isPaused;
            PauseMenu();
        }

        // if (Input.GetKeyDown(KeyCode.Escape) && isPaused) {
        //     Resume();
        // }
    }

    private void UpdateObjectives() {
        if (virusKillCount >= virusCount) {
            objectivesCompleted++;
        }

        if (thrombosisCreated >= thrombosisSpotCount) {
            objectivesCompleted++;
        }

        Debug.Log("Objectives updated");
    }

    public void Respawn() {
        player.GetComponent<Health>().TakeDamage(1);
        player.transform.position = checkpointPosition;
    }

    public void UpdateCheckPosition(Vector3 newPosition) {
        checkpointPosition = newPosition;
    }
    
    public void GameOver() {
        audioManager.StopMusic();
        player.SetActive(false);
        GameOverPanel.SetActive(true);
    }

    public void Retry() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void MainMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void PauseMenu() {

        if (isPaused) {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
        else {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
        
    }

    public void Finish() {
        if (isLevelCompleted) {
            // Time.timeScale = 0;
            audioManager.StopMusic();
            player.SetActive(false);
            finishPanel.SetActive(true);
        }
    }

    public void IncrementVirusKill() {
        virusKillCount++;
        Debug.Log("Virus Killed");
        // UpdateObjectives();
    }

    public void IncrementThrombosisCreatedCount() {
        thrombosisCreated++;
        Debug.Log("1 Thrombosis created");
        // UpdateObjectives();
    }

    public void QuitGame() {
        Application.Quit();
    }

    public static void LoadNextScene()
    {
    //    StartCoroutine(LoadSceneAsynchronously());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }  

    // IEnumerator LoadSceneAsynchronously()
    // {
    //     AsyncOperation operation =  SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    //     finishPanel.SetActive(false);
    //     loadingScreen.SetActive(true);
        
    //     while (!operation.isDone)
    //     {   
    //         loadingBar.value = operation.progress;
    //         LoadingProgressText.text = (operation.progress * 100) + "%";
    //         yield return null;
    //     }
    // }
}
