using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoorController : MonoBehaviour
{
    bool canGoThrough = false;
    private UIInteractionObjectUser uiInteractionObjectUser;

    public void Start()
    {
        uiInteractionObjectUser = GameObject.FindObjectOfType<UIInteractionObjectUser>();
    }

    public void OnTriggerEnter(Collider other)
    {
        
        // Display on UI
        if(GameManager.Won())
        {
            if(other.tag == "Player")
            {
                GetComponent<AudioSource>().Play();
                uiInteractionObjectUser.ShowInteractionText(UIInteractionObjectUser.typeObjet.porte,0);
                canGoThrough = true; 
                
            }
        }
        else
        {
            if(other.tag == "Player")
            {
                uiInteractionObjectUser.ShowInteractionText(UIInteractionObjectUser.typeObjet.porte_locked, GameManager.enemyNumber - GameManager.ennemyKilled); 
            }
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
            GameManager.LoadVictory();
        }
    }
}
