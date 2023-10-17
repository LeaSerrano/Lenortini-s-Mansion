using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class changeLightingMode : MonoBehaviour
{
    public GameObject light;
    Light spotlightChild;

    // Start is called before the first frame update
    void Start()
    {
        spotlightChild = light.GetComponentInChildren<Light>();

    }

    // Update is called once per frame
    void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput > 0)
        {

            if (spotlightChild.intensity < 3)
            {
                spotlightChild.intensity++;
            }
        }
        else if (scrollInput < 0)
        {
            if (spotlightChild.intensity > 0)
            {
                spotlightChild.intensity--;
            }
        }

    }
}
