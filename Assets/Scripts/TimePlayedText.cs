using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class TimePlayedText : MonoBehaviour
{
    [SerializeField] TMP_Text timeText;
    TimeSpan timeSpan;
    string timeString;

    private void Start()
    {
        float time = ScoreKeeper.GetTime();
        timeSpan = TimeSpan.FromSeconds(time);
        timeString = string.Format("Time Played: {0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
        //timeText.text = "Time Survived: " + Mathf.Round(time * 100.0f) * 0.01f; ;
        ScoreKeeper.ResetTime();
    }
}
