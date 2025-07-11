using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Singleton Script for tracking score
/// </summary>
public class ScoreKeeper : MonoBehaviour
{
    private static ScoreKeeper _instance;

    public static ScoreKeeper Instance
    {
        get
        {
            if (_instance == null)
            {
                // Try to find an existing instance
                _instance = FindObjectOfType<ScoreKeeper>();

                if (_instance == null)
                {
                    // Create new GameObject with TimeFreezer
                    GameObject go = new GameObject("TimeFreezer");
                    _instance = go.AddComponent<ScoreKeeper>();

                    // Optional: Prevent from being destroyed on scene load
                    DontDestroyOnLoad(go);
                }
            }
            return _instance;
        }
    }

    private int score = 0;
    private float time = 0;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void DoScoreIncrease()
    {
        score++;
        Debug.Log(score);
    }

    private void resetScore()
    {
        score = 0;
    }

    private int getScore()
    {
        return score;
    }

    private void setTime(float seconds)
    {
        time = seconds;
    }

    private float getTime()
    {
        return time;
    }

    private void resetTime()
    {
        time = 0;
    }

    public static void IncreaseScore()
    {
        Instance.DoScoreIncrease();
    }

    public static int GetScore()
    {
        return Instance.getScore();
    }

    public static void ResetScore()
    {
        Instance.resetScore();
    }

    public static void SetTime(float seconds)
    {
        Instance.setTime(seconds);
    }

    public static float GetTime()
    {
        return Instance.getTime();
    }

    public static void ResetTime()
    {
        Instance.resetTime();
    }

    
}
