using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    bool canGoThrough = false;

    public Animator fader;
    public AudioSource sound;

    private UIInteractionObjectUser uiInteractionObjectUser;

    public void Start()
    {
        uiInteractionObjectUser = GameObject.FindObjectOfType<UIInteractionObjectUser>();
    }

    public void OnTriggerEnter(Collider other)
    {
        // Display on UI
        if(other.tag == "Player")
        {
            Debug.Log("Press R to open door");
            uiInteractionObjectUser.ShowInteractionText(UIInteractionObjectUser.typeObjet.porte);
            canGoThrough = true; 
            
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            uiInteractionObjectUser.HideInteractionText();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(canGoThrough && Input.GetKey("r"))
        {
            fader.SetTrigger("Fade");
            sound.Play();


            canGoThrough = false;
        }
    }
}
