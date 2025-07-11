using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimePlayedText : MonoBehaviour
{
    [SerializeField] TMP_Text timeText;

    private void Start()
    {
        timeText.text = "Time Survived: " + ScoreKeeper.GetTime();
        ScoreKeeper.ResetTime();
    }
}
