using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class DifficultyScaler : MonoBehaviour
{
    [SerializeField] GameObject timeKeeper = null;
    [SerializeField] GameObject spawner = null;

    [Tooltip("List of time thresholds when difficulty increases")]
    [SerializeField] float[] timeThresholds = null;
    [Tooltip("Changes to spawn rate (interval in seconds) linked to the different time thresholds")]
    [SerializeField] float[] spawnRates = null;

    //stores the index of the current difficulty threshold
    int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (timeKeeper == null || spawner == null) { return; } 
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDifficulty();
        //Debug.Log(spawner.GetComponent<Spawner>().GetSpawnRate());
    }

    private void UpdateDifficulty()
    {
        if (currentIndex < timeThresholds.Length-1)
        {
            if (timeThresholds[currentIndex] < timeKeeper.GetComponent<Timekeeper>().getFloatTime())
            {
                currentIndex++;
                spawner.GetComponent<Spawner>().SetSpawnRate(spawnRates[currentIndex]);
            }
        }
    }


}
