using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UICompletionTimeDisplay : MonoBehaviour
{
    public TMP_Text completionTimeText; // Reference to the Text component for displaying the completion time
    public TimerManager timerManager; // Reference to the TimerManager script

    private void Update()
    {
        string completionTime = timerManager.CalculateCompletionTime(); // Calculate the completion time using the TimerManager
        completionTimeText.text = "Completion Time: " + completionTime; // Update the Text component with the completion time
    }
}
