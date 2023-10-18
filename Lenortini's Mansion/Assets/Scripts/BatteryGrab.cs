using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryGrab : MonoBehaviour
{
    bool isInCollider = false;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Press E to get Battery");
            isInCollider = true;
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

        }
    }
}
