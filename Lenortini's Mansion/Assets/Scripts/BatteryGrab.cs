using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryGrab : MonoBehaviour
{
    public GameObject actualBattery;
    private UIInteractionObjectUser uiInteractionObjectUser;

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
            GameVariablesLight.isABatteryGrab = true;
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
        if (GameVariablesLight.isABatteryGrab && Input.GetKey("e"))
        {
            if (GameVariablesLight.maxIntensity < 4)
            {
                Debug.Log(GameVariablesLight.maxIntensity);
                GameVariablesLight.spotlightChild.intensity += 5 - GameVariablesLight.maxIntensity;
                Debug.Log(GameVariablesLight.spotlightChild.intensity);
                Debug.Log(5 - GameVariablesLight.maxIntensity);
                GameVariablesLight.maxIntensity = 3 - GameVariablesLight.maxIntensity;
                Debug.Log(GameVariablesLight.maxIntensity);
                GameVariablesLight.isABatteryGrab = false;
                GameVariablesLight.isResetTimeNeedeed = true;
                Destroy(actualBattery);
            }
            else
            {
                Debug.Log("The battery is full");
            }

        }
    }
}
