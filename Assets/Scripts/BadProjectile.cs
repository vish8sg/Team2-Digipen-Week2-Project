using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadProjectile : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Paddle" || other.tag == "Bitsy")
        {
            createSplotch();
            GetComponent<HealthComponent>().decreaseHealth();
        }
    }

    private void createSplotch()
    {
        SplotchPool.Instance.SpawnSplotch((Vector2) transform.position);
    }
}
