using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TimeManager : MonoBehaviour
{
    //timer component
    public TMP_Text timerText;
    
    //timer settings
    bool TimerActive = false;
    float currentTime;

    //score component
    int score;
    public TMP_Text scoreText;
    public float multiplier = 5;

    private TimeSpan initialTime;
    public TimeSpan timePassed;

      // Countdown timer settings
    public float countdownTime = 240f;
    private bool countdownActive = false;
   
    void Start()
    {
        initialTime = new TimeSpan(System.DateTime.Now.Ticks);
    }

    void Update()
    {
        if (countdownActive)
        {
            // Update the countdown time
            countdownTime -= Time.deltaTime;
            if (countdownTime <= 0f)
            {
                // Countdown is finished
                countdownTime = 0f;
                countdownActive = false;
                TimerActive = false;

                // Display the final timing and score
                TimeSpan finalTimeSpan = TimeSpan.FromSeconds(currentTime);
                timerText.text = finalTimeSpan.ToString(@"mm\:ss");
                scoreText.text = score.ToString();
            }
        }
        else if (TimerActive)
        {
            // Update the current time
            currentTime += Time.deltaTime;

            // Display the timer
            TimeSpan timeSpan = TimeSpan.FromSeconds(currentTime);
            timerText.text = timeSpan.ToString(@"mm\:ss");

            // Calculate and display the score
            score = Mathf.RoundToInt((float)timeSpan.TotalSeconds * multiplier);
            scoreText.text = score.ToString();
        }
    }

    public void StartTimer()
    {
        TimerActive = true;
        countdownActive = true;
    }

    public void StopTimer()
    {
        TimerActive = false;
        countdownActive = false;
    }

    public TimeSpan getTime()
    {
        return timePassed;
    }

    public int getScore()
    {
        return score;
    }
    // void Update()
    // {
    //     // if(TimerActive == true){
    //     //     currentTime = currentTime + Time.deltaTime;
    //     // }

    //     //timer display
    //     TimeSpan currTime = new TimeSpan(System.DateTime.Now.Ticks);
    //     timePassed = currTime - initialTime;

    //     // score display
    //     score = Mathf.RoundToInt((float)timePassed.TotalSeconds * multiplier);
    //     scoreText.text = score.ToString();

    //     // print(timePassed);
    //     timerText.text = timePassed.ToString(@"mm\:ss");
    // }

    // public void StartTimer() {
    //     TimerActive = true;
    // }
    
    // public void StopTimer() {
    //     TimerActive = false;
    // }

    // public TimeSpan getTime() {
    //     return timePassed;
    // }

    // public int getScore() {
    //     return score;
    // }
}
