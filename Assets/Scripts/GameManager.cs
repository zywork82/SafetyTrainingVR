using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private bool isGameStarted = false;
    public GameObject missionPanel;
    public TimerManager timerManager;
    private MissionManager missionManager;

    private void Start()
    {
        // missionManager = get mission manager and check if mission is all completed, aka level complete
        // Update the mission panel text initially
        // UpdateMissionPanelText();
    }

    private void Update()
    {
        // Reference MissionManager.cs
    }

}
