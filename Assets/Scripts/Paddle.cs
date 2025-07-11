using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [Tooltip("Hit stop in seconds when paddle collides with projectile")]
    [SerializeField] float hitStop = 0.05f;

    [Tooltip("How much red gets added to the paddle when it collides with tomato - Range is from 0-1")]
    [SerializeField] float tomatoSplotchAmount = 0.1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "BadProjectile")
        {
            TimeFreezer.FreezeTime(hitStop);
            GetComponent<SpriteRenderer>().color = Color.Lerp(GetComponent<SpriteRenderer>().color, Color.red, tomatoSplotchAmount);
        }
    }
}
