using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Timekeeper : MonoBehaviour
{
    float time;
    TimeSpan timeSpan;
    string timeString;
    bool isRunning = false;
    [SerializeField] TMP_Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        StartTime();
    }

    // Update is called once per frame
    void Update()
    {
        //checks if the time is supposed to be running
        if (isRunning)
        {
            //increase time
            time += Time.deltaTime;

            //sets up TimeSpan object (for formatting)
            timeSpan = TimeSpan.FromSeconds(time);

            //formats the time nicely
            timeString = string.Format("Time On Stage: {0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);

            //sets the text to the time
            timerText.text = timeString;
        }
        //testing stopping the time
        // if (Input.GetKeyDown(KeyCode.A))
        // {
        //     StopTime();
        // }
    }

    public void StopTime()
    {
        isRunning = false;
    }


    public void StartTime()
    {
        isRunning = true;
    }


    //returns the time as a string
    public string getTime()
    {
        return timeString;
    }
}
