using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadProjectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Paddle" || other.tag == "Bitsy")
        {
            CameraShake.Shake(0.1f, 1f);
            GetComponent<HealthComponent>().decreaseHealth();
        }
        if (other.tag == "Bitsy")
        {
            GetComponent<HealthComponent>().decreaseHealth();
        }
    }
}
