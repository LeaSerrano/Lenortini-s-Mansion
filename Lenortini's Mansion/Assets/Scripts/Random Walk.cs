using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomWalk : MonoBehaviour
{
    public float mRange = 25.0f;
    public float minPauseTime = 1.0f;  // Temps minimal d'arrêt.
    public float maxPauseTime = 5.0f;  // Temps maximal d'arrêt.
    public float distanceDetection = 25.0f;

    private Vector2 lastPos;
    private NavMeshAgent ghost;
    private Vector2 randomPos;
    private bool isPaused;
    private float pauseTimer;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        ghost = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        SetNewRandomDestination();
    }

    // Update is called once per frame
    void Update()
    {   
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, distanceDetection))
        {
            if (hit.collider.CompareTag("Player"))
            {
                // Si le joueur est détecté, définissez la destination vers le joueur.
                ghost.SetDestination(hit.transform.position);
                isPaused = false;  // Assurez-vous que l'arrêt est désactivé lorsque le joueur est détecté.
                Debug.Log("Player detected !");
            }
        }

        if (!isPaused)
        {
            if (ghost.remainingDistance <= 0.1f)
            {
                isPaused = true;
                pauseTimer = Random.Range(minPauseTime, maxPauseTime);
            }
        }
        else
        {
            pauseTimer -= Time.deltaTime;
            if (pauseTimer <= 0)
            {
                isPaused = false;
                SetNewRandomDestination();
            }
        }

        /* if(isPosSet){
            
        } */
    }

    // Définit une nouvelle destination aléatoire pour l'objet.
    private void SetNewRandomDestination()
    {
        randomPos = Random.insideUnitCircle * mRange;
        if (randomPos == lastPos)
        {
            randomPos = Random.insideUnitCircle * mRange;
        }
        ghost.destination = new Vector3(randomPos.x, 0, randomPos.y);
        lastPos = randomPos;

        //IsPosSet = true;
    }

    void SetStopped()
    {
        ghost.isStopped = true;
    }
}
