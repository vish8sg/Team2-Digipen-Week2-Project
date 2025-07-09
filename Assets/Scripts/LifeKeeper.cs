using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LifeKeeper : MonoBehaviour
{
    [SerializeField] GameObject bitsy = null;
    int lives;
    string livesString;
    [SerializeField] TMP_Text livesText;
    // Start is called before the first frame update
    void Start()
    {
        lives = bitsy.GetComponent<HealthComponent>().GetLives();
        livesString = "Lives: " + lives;
    }

    // Update is called once per frame
    void Update()
    {
        livesString = "Lives: " + lives;
        livesText.text = livesString;

        //testing
        // if (Input.GetKeyDown(KeyCode.Q))
        // {
        //     IncreaseLife();
        // }
        // if (Input.GetKeyDown(KeyCode.W))
        // {
        //     DecreaseLife();
        // }
    }

    public void updateLife(int health)
    {
        lives = health;
    }

    public int getLives()
    {
        return lives;
    }
}
