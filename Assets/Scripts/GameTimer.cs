using System;
using System.Collections;
using Unity.IntegerTime;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    private int timeRemaining;
    private bool isStopped;
    
    private Action methodToCallWhenTimeIsOver;
    
    public void StartTimer(int durationInSeconds, Action methodToCallWhenTimeIsOver)
    {
        this.methodToCallWhenTimeIsOver = methodToCallWhenTimeIsOver;
        timeRemaining = durationInSeconds;
        StartCoroutine(TickOneSecond());
    }

    public void StopTimer()
    {
        timeRemaining = 0;
        isStopped = true;
        methodToCallWhenTimeIsOver.Invoke();
    }

    public string GetTimeAsString()
    {
        int minutes = timeRemaining / 60;
        int seconds = timeRemaining - (minutes * 60);
        string minutesAsString = string.Format("{0:00}", minutes);
        string secondsAsString = string.Format("{0:00}", seconds);
        
        return minutesAsString + ":" + secondsAsString;
    }

    public bool IsTimerRunning()
    {
        return !isStopped;
    }

    IEnumerator TickOneSecond()
    {
        yield return new WaitForSeconds(1);
        
        if (!isStopped)
        {
            timeRemaining = timeRemaining - 1;
            if (timeRemaining > 0)
            {
                StartCoroutine(TickOneSecond());
            }

            else
            {
                StopTimer();
            } 
        }
    }
}
