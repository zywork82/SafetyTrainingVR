using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/**
    Mission manager for current level only, where all mission managers are managed by Game manager.
*/
public class MissionManager : MonoBehaviour
{
    public GameObject missionPanel;
    public TMP_Text missionDesc;
    public GameObject fireExtinguisher;
    
    public bool isFireExtinguisherPickedUp = false;
    public bool isFlamePutOut = false;

    private List<Mission> missions = new List<Mission>();

    void Start() {
        // Level 1 missions
        missions.Add(new Mission("Find and grab the fire extinguisher"));
        missions.Add(new Mission("Put out the fire"));

        UpdateMissionPanel();
        // Start the timer
        // timerManager.StartTimer();
    }

    void Update() {
        if (isFireExtinguisherPickedUp && isFlamePutOut) {
            // Level complete
        }
    }

    // Mission 1
    public void FireExtinguisherPickedUp()
    {
        print("fire extinguisher grabbed");
        isFireExtinguisherPickedUp = true;

        print("completed mission 1: " + isMissionCompletedById(0));
    }

    // Mission 2
    public void FlamePutOut()
    {
        print("flame is put out, game ends");
        isFlamePutOut = true;

        print("completed mission 2: " + isMissionCompletedById(1));
    }
    
    private void UpdateMissionPanel() {
        missionDesc.text = "";
        /* Missions to be dealt with in sequence, to update later */
        foreach (Mission mission in missions)
        {
            if (mission.isCompleted) {
                missionDesc.text += $"<s>{mission.missionName}</s>\n";
                // mission.completionTimeText = timerManager.CalculateCompletionTime();
            }
            else {
                missionDesc.text += $"{mission.missionName}\n";
            }
        }
    }

    public bool isMissionCompletedById(int Id) {
        Mission mission = missions.Find(m => m.Id == Id);
        if (mission != null) {
            mission.CompleteMission();
            UpdateMissionPanel();
            // timerManager.StartTimer();
            return true;
        }
        return false;
    }

    public class Mission
    {
        public static int missionId = 0;
        public int Id;
        public string missionName;
        public bool isCompleted;

        public Mission(string name)
        {
            Id = Mission.missionId++;
            missionName = name;
            isCompleted = false;
        }

        public void CompleteMission()
        {
            isCompleted = true;
        }
    }
}
