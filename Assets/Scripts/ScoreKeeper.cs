using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public static ScoreKeeper instance;

    private int score = 0;

    [SerializeField] TMP_Text scoreText = null;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        scoreText.text = "Score: " + score;
    }

    private void DoScoreIncrease()
    {
        score++;
        Debug.Log(score);
        scoreText.text = "Score: " + score;
    }

    public static void IncreaseScore()
    {
        instance.DoScoreIncrease();
    }
}
