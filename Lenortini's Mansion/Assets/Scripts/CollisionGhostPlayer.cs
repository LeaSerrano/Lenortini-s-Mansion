using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CollisionGhostPlayer : MonoBehaviour
{
    private NavMeshAgent ghost;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        ghost = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            Debug.Log("Player touched !");
        }
    }


}
