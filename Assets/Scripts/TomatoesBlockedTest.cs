using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TomatoesBlockedTest : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Tomatoes Blocked: " + ScoreKeeper.GetScore();
        ScoreKeeper.ResetScore();
    }
}
