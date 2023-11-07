using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightRayCaster : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(gameObject.GetComponent<Light>().intensity <= 0.0f) return;
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10.0f))
        {
            if(hit.collider.CompareTag("Ghost"))
            {
                hit.transform.gameObject.GetComponent<Animator>().SetTrigger("Killed");
                GameVariablesLight.isDamaging = true;
            }
            
            
            
        }
    }
}
