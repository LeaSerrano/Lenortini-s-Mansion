using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class CollisionGhostPlayer : MonoBehaviour
{
    private NavMeshAgent ghost;
    private GameObject player;
    public float cooldownDuration = 2.0f;
    private float lastCollisionTime;
    public bool isDead = false;

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
        if(other.CompareTag("Player")) {
            if ((Time.time - lastCollisionTime >= cooldownDuration) && !isDead)
            {
                PlayerHealth.Instance.Hurt(1);
                lastCollisionTime = Time.time;

                other.GetComponent<Knockback>().ApplyKnockback(0.3f);
            }
        }
    }
}
