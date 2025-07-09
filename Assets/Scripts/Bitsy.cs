using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bitsy : MonoBehaviour
{
    [SerializeField] GameObject lifeKeeper = null;

    HealthComponent healthComponent = null;
    void Start()
    {
        healthComponent = GetComponent<HealthComponent>();
        lifeKeeper.GetComponent<LifeKeeper>().updateLife(healthComponent.GetLives());
    } 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "BadProjectile")
        {
            GetComponent<HealthComponent>().decreaseHealth();
            lifeKeeper.GetComponent<LifeKeeper>().updateLife(healthComponent.GetLives());
        }
    }
}
