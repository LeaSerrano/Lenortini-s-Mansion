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
        Debug.Log(GameManager.enemyNumber + "enemies remaining");
        // Display on UI
        if(GameManager.enemyNumber <= 0 && other.tag == "Player")
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
            GameManager.LoadVictory();
        }
    }
}
