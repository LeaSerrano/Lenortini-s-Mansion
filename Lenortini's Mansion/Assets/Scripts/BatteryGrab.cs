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
            uiInteractionObjectUser.ShowInteractionText(UIInteractionObjectUser.typeObjet.batterie, 0);
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
            if (GameVariablesLight.maxIntensity < 3)
            {
                GameVariablesLight.spotlightChild.intensity = 3;
                GameVariablesLight.maxIntensity = 3;
                GameVariablesLight.isResetTimeNeedeed = true;
                Destroy(gameObject);
                uiInteractionObjectUser.HideInteractionText();
            }
            else
            {
                uiInteractionObjectUser.ShowInteractionText(UIInteractionObjectUser.typeObjet.batterie_pleine, 0);
            }

            isInCollider = false;

        }

    }
}
