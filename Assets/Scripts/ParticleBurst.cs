using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBurst : MonoBehaviour
{
    [SerializeField] ParticleSystem tomatoParticles = null;
    [SerializeField] GameObject origin = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "BadProjectile")
        {
            tomatoParticles.transform.position = origin.transform.position;
            Quaternion opposite = Quaternion.Inverse(origin.transform.rotation);
            tomatoParticles.transform.rotation = opposite;
            tomatoParticles.Play();
        }
    }
}
