using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject missionPanel;
    public MissionPanelUI missionDesc;
    public GameObject fireExtinguisher;

    private bool fireExtinguisherPickedUp = false;

    private void Start()
    {
        // Update the mission panel text initially
        UpdateMissionPanelText();
    }

    private void Update()
    {
        // Add your code to check for player interactions or events

        // Example: If the player picks up the fire extinguisher, update the mission
        if (fireExtinguisherPickedUp)
        {
            CompleteMission("Find the fire extinguisher");
        }
    }

    private void UpdateMissionPanelText()
    {
        if (missionDesc != null)
        {
            // Update the mission panel UI with the current task
            missionDesc.UpdateTaskText("Find the fire extinguisher");

            // You can add more missions/tasks here
        }
    }

    public void CompleteMission(string missionName)
    {
        if (missionDesc != null)
        {
            // Mark the mission as completed in the UI
            missionDesc.StrikeThroughText();
        }
    }

    // Call this method when the fire extinguisher is picked up
    public void PickUpFireExtinguisher()
    {
        fireExtinguisherPickedUp = true;
          // Hide or disable the fire extinguisher object
        fireExtinguisher.SetActive(false);

     // Call the CompleteMission method to update the mission status
        CompleteMission("Find the fire extinguisher");
    }
}
