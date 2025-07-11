using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimePlayedText : MonoBehaviour
{
    [SerializeField] TMP_Text timeText;

    private void Start()
    {
        float time = ScoreKeeper.GetTime();
        timeText.text = "Time Survived: " + Mathf.Round(time * 100.0f) * 0.01f; ;
        ScoreKeeper.ResetTime();
    }
}
