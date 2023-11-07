using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostKill : MonoBehaviour
{
    public AudioClip diesound;
    void Die()
    {
        

        Destroy(gameObject);
    }

    void PlayDeathSound()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Stop();
        audio.clip = diesound;
        audio.Play();
        Debug.Log("dead");
    }
}
