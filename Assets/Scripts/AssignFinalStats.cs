using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class AssignFinalStats : MonoBehaviour
{
    [SerializeField] TMP_Text timeAlive;
    [SerializeField] TMP_Text tomatoesBlocked;
    TimeSpan timeSpan;
    string timeString;
    // Start is called before the first frame update
    void Start()
    {
        timeSpan = TimeSpan.FromSeconds(ScoreKeeper.GetTime());
        timeString = string.Format("Time Played: {0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
        timeAlive.text = timeString;
        tomatoesBlocked.text = "Tomatoes Blocked: " + ScoreKeeper.GetScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
