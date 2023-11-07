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

            if (GameVariablesLight.spotlightChild.intensity < GameVariablesLight.maxIntensity - 1)
            {
                GameVariablesLight.spotlightChild.intensity++;
            }
        }
        else if (scrollInput < 0)
        {
            if (GameVariablesLight.spotlightChild.intensity > 0)
            {
                GameVariablesLight.spotlightChild.intensity--;
            }
        }

    }
}
