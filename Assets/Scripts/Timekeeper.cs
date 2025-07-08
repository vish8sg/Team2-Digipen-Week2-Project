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
    [SerializeField] TMP_Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeSpan = TimeSpan.FromSeconds(time);
        timerText.text = string.Format("Time On Stage: {0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
    }
}
