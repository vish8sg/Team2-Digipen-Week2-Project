using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadProjectile : MonoBehaviour
{
    [SerializeField] GameObject splotchPrefab = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Paddle" || other.tag == "Bitsy")
        {
            SpawnSplotch();
            GetComponent<HealthComponent>().decreaseHealth();
        }
    }

    private void SpawnSplotch()
    {
        SplotchPool.Instance.SpawnSplotch((Vector2) transform.position);
    }
}
