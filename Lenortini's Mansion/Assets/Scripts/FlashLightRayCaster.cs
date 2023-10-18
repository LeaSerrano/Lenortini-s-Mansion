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
        

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if(hit.collider.CompareTag("Ghost"))
            {
                /*Debug.Log("Kill ghost");*/
                hit.transform.gameObject.GetComponent<Animator>().SetTrigger("Killed");
            }
            
            
            
        }
    }
}
