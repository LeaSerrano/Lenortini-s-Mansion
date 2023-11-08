using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightRayCaster : MonoBehaviour
{
    private bool isTheGhostHit = false;
    private bool shouldDecremented = false;

    private RaycastHit hit;

    void FixedUpdate()
    {
        isTheGhostHit = false;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5.0f))
        {
            if (hit.collider.CompareTag("Ghost") && GameVariablesLight.spotlightChild.intensity>0)
            {
                isTheGhostHit = true;
                hit.transform.gameObject.GetComponent<Animator>().SetTrigger("Killed");
                hit.transform.gameObject.GetComponent<CollisionGhostPlayer>().isDead = true;
            }
        }
    }

    void Update()
    {
        if (isTheGhostHit && !shouldDecremented)
        {
            shouldDecremented = true;

            if (GameVariablesLight.maxIntensity > 0)
            {
                GameVariablesLight.maxIntensity--;
                GameVariablesLight.spotlightChild.intensity = GameVariablesLight.maxIntensity;

                if (GameVariablesLight.maxIntensity == 2)
                {
                    GameVariablesLight.timeRemaining = GameVariablesLight.timeRemaning3BatteryLevel;
                }
                else if (GameVariablesLight.maxIntensity == 1)
                {
                    GameVariablesLight.timeRemaining = GameVariablesLight.timeRemaning2BatteryLevel;
                }
                else if (GameVariablesLight.maxIntensity == 0)
                {
                    GameVariablesLight.timeRemaining = GameVariablesLight.timeRemaning1BatteryLevel;
                }
            }
            GameManager.enemyNumber --;
        }

        if (!isTheGhostHit)
        {
            shouldDecremented = false;
        }
    }
}

