using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndScreenStats : MonoBehaviour
{
    string timeAlive;
    [SerializeField] Timekeeper timekeeper = null;
    [SerializeField] TMP_Text timeAliveText;

    // Start is called before the first frame update
    void Start()
    {
        timeAlive = timekeeper.getTime();
    }

    // Update is called once per frame
    void Update()
    {
        timeAliveText.text = timeAlive;
    }
}
