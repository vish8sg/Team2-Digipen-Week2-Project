using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] int MaxHealth = 1;
    int health;
    private void Awake()
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

    public void increaseHealth()
    {
        health++;
        health = Mathf.Clamp(health, 0, MaxHealth);
    }

    public int GetLives()
    {
        return health;
    }
}
