using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bitsy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "BadProjectile")
        {
            GetComponent<HealthComponent>().decreaseHealth();
        }
    }
}
