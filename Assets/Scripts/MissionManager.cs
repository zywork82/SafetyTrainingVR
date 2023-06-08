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

    void Start()
    {
        // Add your missions to the list
        missions.Add(new Mission("Find the fire extinguisher", "Locate the fire extinguisher in the game room"));
        missions.Add(new Mission("Put out the fire", "Extinguish the fire using the fire extinguisher"));

        // Update the mission panel initially
        UpdateMissionPanel();

        // Start the timer
        // timerManager.StartTimer();
    }

    private void UpdateMissionPanel()
    {
        missionDesc.text = "";
        foreach (Mission mission in missions)
        {
            if (mission.isCompleted)
            {
                missionDesc.text += $"<s>{mission.missionName}</s>\n";
                // mission.completionTimeText = timerManager.CalculateCompletionTime();
            }
            else
            {
                missionDesc.text += $"{mission.missionName}\n";
            }
        }
    }

    public void CompleteMissionById(int Id)
    {
        // Find the mission with the specified id
        //in the list of "missions" find the Id that belongs to what is called
        Mission mission = missions.Find(m => m.Id == Id);
        if (mission != null)
        {
            // Complete the mission
            mission.CompleteMission();

            // Update the mission panel and completion time
            UpdateMissionPanel();

            // Start the timer again
            // timerManager.StartTimer();
        }
    }

    public class Mission
    //every new misssion will have all this values
    {
        //static int so this mission Id only change inside this class, asssigning original mission Id to 0
        public static int missionId = 0;
        //Id is just a variable that can be changed
        public int Id;
        public string missionName;
        public string missionDescription;
        public bool isCompleted;
        public string completionTimeText;

        public Mission(string name, string description)
        {
            //Id number is called and changed here
            Id = Mission.missionId++;
            missionName = name;
            missionDescription = description;
            isCompleted = false;
            // completionTimeText = ""; // Initialize the completion time text
        }

        public void CompleteMission()
        {
            isCompleted = true;
        }
    }
}
