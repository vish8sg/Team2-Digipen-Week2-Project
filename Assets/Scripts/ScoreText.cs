using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText = null;

    private void Start()
    {
        if (scoreText == null) { return; }
    }

    private void Update()
    {
        scoreText.text = "Score: " + ScoreKeeper.GetScore();
    }
}
