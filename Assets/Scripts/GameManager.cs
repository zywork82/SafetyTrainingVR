using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
// using UnityEngine.SceneManager;

public class GameManager : MonoBehaviour
{
    private bool isGameStarted = false;
    public GameObject missionPanel;
    public TimeManager timeManager;
    public MissionManager missionManager;
    public GameObject trainingEndInterface;
    public TMP_Text timerText;
    public TMP_Text scoreText;
    public TMP_Text completionTimeText;
    // private Scene currScene;

    private void Start()
    {
        
    }

    public void RestartScene() {

    }

    private void Update()
    {
       if(missionManager.isLevelCompleted()) {
            // print("gamemanager: level is completed");
            trainingEndInterface.SetActive(true);
            // print("trgendcanvas");
            missionPanel.SetActive(false);
            // print("missionPanelDisappear");
            timerText.gameObject.SetActive(false);
            // print("timerDisappear");

            scoreText.text = timeManager.getScore().ToString();
            scoreText.gameObject.SetActive(true);
            // print("score appear");
            completionTimeText.text = timeManager.getTime().ToString(@"mm\:ss");
            completionTimeText.gameObject.SetActive(true);
            // print("complete time appear");
     }
    //    } else {
    //     print("hi");
    //    }
    

}
}