// TimerUI.cs
// This script displays a timer on the UI using TextMeshPro.
// It can be set to count down from a specified time or count up like a stopwatch.
// The time is shown in MM:SS format and updates every frame.


using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    public float timeRemaining = 60f; // set your starting time here
    public bool isCountdown = true;   // true = countdown, false = stopwatch
    public TMP_Text timerText;

    void Update()
    {
        if (isCountdown && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else if (!isCountdown)
        {
            timeRemaining += Time.deltaTime;
        }

        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
