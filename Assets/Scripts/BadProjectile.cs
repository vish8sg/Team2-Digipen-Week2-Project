using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadProjectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Paddle")
        {
            if (Camera.main.GetComponent<CameraShake>() != null) { CameraShake.Shake(0.05f, 0.25f); }
        }
        GetComponent<HealthComponent>().decreaseHealth();
    }
}
