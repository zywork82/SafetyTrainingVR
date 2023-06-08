using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MissionManager : MonoBehaviour
{
    public GameObject missionPanel;
    public TMP_Text missionDesc;
    public TimerManager timerManager;

    private List<Mission> missions = new List<Mission>();

    private void Start()
    {
        // Add your missions to the list
        missions.Add(new Mission("Find the fire extinguisher", "Locate the fire extinguisher in the game room"));
        missions.Add(new Mission("Put out the fire", "Extinguish the fire using the fire extinguisher"));

        // Update the mission panel initially
        UpdateMissionPanel();

        // Start the timer
        timerManager.StartTimer();
    }

    private void UpdateMissionPanel()
    {
        missionDesc.text = "";
        foreach (Mission mission in missions)
        {
            if (mission.isCompleted)
            {
                missionDesc.text += $"<s>{mission.missionName}</s>\n";
                mission.completionTimeText = timerManager.CalculateCompletionTime();
            }
            else
            {
                missionDesc.text += $"{mission.missionName}\n";
            }
        }
    }

    public void CompleteMissionByName(string missionName)
    {
        // Find the mission with the specified name
        Mission mission = missions.Find(m => m.missionName == missionName);
        if (mission != null)
        {
            // Complete the mission
            mission.CompleteMission();

            // Update the mission panel and completion time
            UpdateMissionPanel();

            // Start the timer again
            timerManager.StartTimer();
        }
    }

    public class Mission
    {
        public string missionName;
        public string missionDescription;
        public bool isCompleted;
        public string completionTimeText;

        public Mission(string name, string description)
        {
            missionName = name;
            missionDescription = description;
            isCompleted = false;
            completionTimeText = ""; // Initialize the completion time text
        }

        public void CompleteMission()
        {
            isCompleted = true;
        }
    }
}
