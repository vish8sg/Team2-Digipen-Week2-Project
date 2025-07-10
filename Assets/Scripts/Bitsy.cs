using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bitsy : MonoBehaviour
{
    [SerializeField] GameObject lifeKeeper = null;
    [SerializeField] GameObject sceneLoader = null;

    [Tooltip("Time in seconds which Bisty will be invulnerable after getting hit")]
    [SerializeField] float invulnerabiltyWindow = 1f;
    [Tooltip("Time between invulnerability ticks")]
    [SerializeField] float invulnerabilityDeltaTime = 0.15f;

    HealthComponent healthComponent = null;
    bool isInvulnerable = false;

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
            if (isInvulnerable) { return; }
            GetComponent<HealthComponent>().decreaseHealth();
            lifeKeeper.GetComponent<LifeKeeper>().updateLife(healthComponent.GetLives());
            //CameraShake.Shake(0.05f, 0.5f);
            StartCoroutine(BecomeTemporarilyInvincible());

            //restarts game if bitsy's lives goes to zero
            if (healthComponent.GetLives() <= 0)
            {
                sceneLoader.GetComponent<SceneLoader>().LoadScene(0);
            }
        }
    }

    private IEnumerator BecomeTemporarilyInvincible()
    {
        isInvulnerable = true;

        for (float i = 0; i < invulnerabiltyWindow; i += invulnerabilityDeltaTime)
        {
            // TODO: add any logic we want here
            Color invulnerableRed = new Color(1f, 0.5f, 0.5f);
            GetComponent<SpriteRenderer>().color = invulnerableRed;
            yield return new WaitForSeconds(invulnerabilityDeltaTime/2);
            GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(invulnerabilityDeltaTime / 2);
        }
        isInvulnerable = false;
    }
}
