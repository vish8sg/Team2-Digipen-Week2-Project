using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] int MaxHealth = 1;
    int health;
    private void Start()
    {
        health = MaxHealth;
    }

    public void decreaseHealth()
    {
        health--;
        if (health <= 0)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
