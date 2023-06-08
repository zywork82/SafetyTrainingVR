using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    private float startTime;
    public float completionTime;

    public void StartTimer()
    {
        startTime = Time.time;
    }

    public string CalculateCompletionTime()
    {
        float elapsedTime = Time.time - startTime;
        string completionTimeText = elapsedTime.ToString("F2");
        return completionTimeText;
    }
}
