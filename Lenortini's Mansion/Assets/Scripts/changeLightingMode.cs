using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class changeLightingMode : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput > 0)
        {
            if (GameVariablesLight.spotlightChild.intensity < GameVariablesLight.maxIntensity)
            {
                GameVariablesLight.spotlightChild.intensity += 1;
                if (GameVariablesLight.spotlightChild.intensity > GameVariablesLight.maxIntensity)
                {
                    GameVariablesLight.spotlightChild.intensity = GameVariablesLight.maxIntensity;
                }
            }
        }
        else if (scrollInput < 0)
        {
            if (GameVariablesLight.spotlightChild.intensity > 0.0f)
            {
                GameVariablesLight.spotlightChild.intensity -= 1;
                if (GameVariablesLight.spotlightChild.intensity < 0.0f)
                {
                    GameVariablesLight.spotlightChild.intensity = 0.0f;
                }
            }
        }
    }


}
