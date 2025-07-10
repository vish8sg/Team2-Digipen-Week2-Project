using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTomatoSFX : MonoBehaviour
{
    [SerializeField] AudioSource clip;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "BadProjectile")
            playClip();
    }
    

    public void playClip()
    {
        clip.Play();
    }   
}
