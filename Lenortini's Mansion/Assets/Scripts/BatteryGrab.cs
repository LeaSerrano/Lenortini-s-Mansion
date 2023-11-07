using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryGrab : MonoBehaviour
{
    private UIInteractionObjectUser uiInteractionObjectUser;
    private bool isInCollider = false;

    public void Start()
    {
        uiInteractionObjectUser = GameObject.FindObjectOfType<UIInteractionObjectUser>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Press E to get Battery");
            uiInteractionObjectUser.ShowInteractionText(UIInteractionObjectUser.typeObjet.batterie);
            isInCollider = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            uiInteractionObjectUser.HideInteractionText();
        }
    }

    public void Update()
    {
        if (isInCollider && Input.GetKey("e"))
        {
            if (GameVariablesLight.maxIntensity < 4)
            {
                GameVariablesLight.spotlightChild.intensity = 3;
                GameVariablesLight.maxIntensity = 4;
                GameVariablesLight.isResetTimeNeedeed = true;
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("The battery is full");
            }

            isInCollider = false;

        }

    }
}
