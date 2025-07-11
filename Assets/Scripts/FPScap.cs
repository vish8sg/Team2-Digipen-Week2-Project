using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPScap : MonoBehaviour
{
    [Tooltip("Sets target frame rate for the game")]
    [SerializeField] int targetFR = 60;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }
}
