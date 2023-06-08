using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MissionPanelUI : MonoBehaviour
{
    public TMP_Text missionDesc;

    public void UpdateTaskText(string taskText)
    {
        missionDesc.text = taskText;
    }

    public void StrikeThroughText()
    {
        missionDesc.text = $"<s>{missionDesc.text}</s>";
    }

    public void CompleteMission(string missionName)
    {
        StrikeThroughText();
    }
}
