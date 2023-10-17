using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryGrab : MonoBehaviour
{
    bool hit = false;
    public void OnTriggerEnter(Collider other)
    {
        // Display on UI
        if(other.tag == "Player")
        {
            Debug.Log("Press E to get Battery");
            hit = true; 
        }
    }

    public void Update()
    {
        if(hit && Input.GetKey("e"))
        {
            Destroy(gameObject);
        }
    }
}
