using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    //Sets up static CameraShake Instance
    public static CameraShake Instance;

    private void Awake() => Instance = this;

    private void OnShake(float duration, float strength)
    {
        transform.DOShakePosition(duration, strength);
        transform.DOShakeRotation(duration, strength);
    }

    //Static Camera Shake method that can be used in other scripts without passing a referenfce to a camera shake object
    public static void Shake(float duration, float strength) => Instance.OnShake(duration, strength);
}
