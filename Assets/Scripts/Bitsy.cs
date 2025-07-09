using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bitsy : MonoBehaviour
{
    [SerializeField] GameObject lifeKeeper = null;
    [SerializeField] GameObject sceneLoader = null;

    HealthComponent healthComponent = null;
    void Start()
    {
        if (lifeKeeper == null || sceneLoader == null) { return; }
        healthComponent = GetComponent<HealthComponent>();
        lifeKeeper.GetComponent<LifeKeeper>().updateLife(healthComponent.GetLives());
    } 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "BadProjectile")
        {
            GetComponent<HealthComponent>().decreaseHealth();
            lifeKeeper.GetComponent<LifeKeeper>().updateLife(healthComponent.GetLives());

            //restarts game if bitsy's lives goes to zero
            if (healthComponent.GetLives() <=0 )
            {
                sceneLoader.GetComponent<SceneLoader>().LoadScene(0);
            }
        }
    }
}
