using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIControllers : MonoBehaviour
{
    public GameObject controlsPanel;
    public GameObject trainingStartInterface;
    public GameObject flameEnvironment;
    public GameObject missionPanel;
    public GameObject timerText;
    public TimeManager timeManager;

    private void Start() {
        controlsPanel.SetActive(false);
        flameEnvironment.SetActive(false);
        missionPanel.SetActive(false);
        timerText.SetActive(false);
    }

    public void StartGame() {
        trainingStartInterface.SetActive(false);
        flameEnvironment.SetActive(true);
        missionPanel.SetActive(true);
        timerText.SetActive(true);
        timeManager.StartTimer();
        print("timer has started");
        timeManager.getTime();
        print("time gotten");
    }

    public void QuitTraining() {
        Application.Quit();
    }
        
    public void ShowInstructions() {
        controlsPanel.SetActive(!controlsPanel.activeSelf);
    }

    public void CloseInstructions(){
        controlsPanel.SetActive(false);
    }


    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMainMenu() {
        SceneManager.LoadScene("MainVRScene");
    }

}
