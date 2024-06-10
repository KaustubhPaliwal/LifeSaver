using System.Collections;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 0;
    public TMP_Text timeText;

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
        }
        else
        {
            // Timer has reached zero
            timeRemaining = 0;
            DisplayTime(timeRemaining);
            // Perform actions when the timer ends
            // For example, you can call a method or set a flag indicating the end of the timer
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliseconds = Mathf.FloorToInt((timeToDisplay - Mathf.FloorToInt(timeToDisplay)) * 1000); // Calculate milliseconds

        timeText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds); // Include milliseconds in the format string
    }
}
