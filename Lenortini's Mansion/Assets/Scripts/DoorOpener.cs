using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    bool canGoThrough = false;

    public Animator fader;
    public AudioSource sound;
    public Transform inSpawn;
    public Transform outSpawn;

    public AudioClip unlockSound;
    public AudioClip openSound;

    private UIInteractionObjectUser uiInteractionObjectUser;

    public bool isLocked;
    public int nbEnnemyKilledToUnlock;

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
            uiInteractionObjectUser.ShowInteractionText(isLocked? UIInteractionObjectUser.typeObjet.porte_locked : UIInteractionObjectUser.typeObjet.porte);
            canGoThrough = !isLocked; 
            
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
        if(isLocked) 
        {
            isLocked = GameManager.ennemyKilled != nbEnnemyKilledToUnlock;
            // Play sound of unlocking if unlocking at this frame
            if(!isLocked)
            {
                sound.clip = unlockSound;
                sound.Play();
                Debug.Log("Unlock sound");
            }
        }

        
        if(canGoThrough && Input.GetKey("r"))
        {
            fader.gameObject.GetComponent<DoorTeleporter>().inSpawn = inSpawn;
            fader.gameObject.GetComponent<DoorTeleporter>().outSpawn = outSpawn;
            fader.SetTrigger("Fade");
            sound.clip = openSound;
            sound.Play();


            canGoThrough = false;
        }
    }
}
