using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    bool canGoThrough = false;

    public Animator fader;
    public AudioSource sound;

    public void OnTriggerEnter(Collider other)
    {
        // Display on UI
        if(other.tag == "Player")
        {
            Debug.Log("Press E to open door");
            canGoThrough = true; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(canGoThrough && Input.GetKey("e"))
        {
            fader.SetTrigger("Fade");
            sound.Play();


            canGoThrough = false;
        }
    }
}
