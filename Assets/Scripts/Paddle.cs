using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [Tooltip("Hit stop in seconds when paddle collides with projectile")]
    [SerializeField] float hitStop = 0.05f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "BadProjectile")
        {
            TimeFreezer.FreezeTime(hitStop);
        }
    }
}
