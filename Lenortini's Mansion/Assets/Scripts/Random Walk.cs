using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomWalk : MonoBehaviour
{
    public float moveSpeed = 0.5f; // Vitesse de déplacement du fantôme

    public float mRange = 25.0f;
    public float minPauseTime = 1.0f;  // Temps minimal d'arrêt.
    public float maxPauseTime = 5.0f;  // Temps maximal d'arrêt.
    public float distanceDetection = 50.0f;

    private Vector2 lastPos;
    private NavMeshAgent ghost;
    private Vector2 randomPos;

    private bool isPaused;
    private float pauseTimer;

    private bool activatedHitTimer = false;
    private float hitTimer; // Temps avant de pouvoir hit à nouveau

    private Vector3 offset = new Vector3(0.25f,0.0f,0.25f);

    private bool playerDetected;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        ghost = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        isPaused = false;
        SetNewRandomDestination();
    }

    // Update is called once per frame
    void Update()
    {   
        if(activatedHitTimer && hitTimer >= 0){ // Si le hit timer est activé et >= 0
            hitTimer -= Time.deltaTime; // Diminue le temps
            //Debug.Log("hitTimer : "+ hitTimer);
        } 
        if(hitTimer <= 0){ // Si le hit timer est <= 0
            activatedHitTimer = false; // Désactivation du timer
            hitTimer = 0; // Remise du timer à 0
        } 

        if (!isPaused) // si le fantome n'est pas statique
        {
            hitting();
            if (ghost.remainingDistance <= 0.2f) // si distance bien effectuée
            {
                isPaused = true; // fantome statique
                pauseTimer = Random.Range(minPauseTime, maxPauseTime); // set temps de pause
            }
        }
        else // si le fantome est statique
        {
            hitting();
            pauseTimer -= Time.deltaTime; // diminution du temps de pause
            if (pauseTimer <= 0) // compteur de pause à 0 -> fin de pause
            {
                isPaused = false; 
                if(!playerDetected)
                {
                    SetNewRandomDestination(); // Nouvelle direction
                }
                
            }
        }

    }

    private void hitting(){
        RaycastHit hit;
        float detectionAngle = 30.0f;
        float halfAngle = detectionAngle / 2.0f;
        Quaternion leftAngle = Quaternion.Euler(0, -halfAngle, 0); // Angle de 15deg sur la gauche
        Quaternion rightAngle = Quaternion.Euler(0, halfAngle, 0); // Angle de 15deg sur la droite
        Vector3 leftDirection = leftAngle * transform.forward;
        Vector3 rightDirection = rightAngle * transform.forward;

        if (Physics.Raycast(transform.position, leftDirection, out hit, distanceDetection) ||Physics.Raycast(transform.position, rightDirection, out hit, distanceDetection) )
        {
            if (hit.collider.CompareTag("Player") && !activatedHitTimer) // Si le joueur est détecté et que le timer est désactivé
            {
                playerDetected = true;
                ghost.SetDestination(hit.transform.position - offset);
                ghost.speed = 3.0f; 
                isPaused = false; 
                Debug.Log("Player detected by hit !");
                activatedHitTimer = true; // Activation du hit timer
                hitTimer = 2.0f; // 2 sec de hit timer
            } else if (!activatedHitTimer) { // Si le joueur n'est pas détecté et le timer est désactivé
                playerDetected = false;
                //Debug.Log("Player NOT detected by hit !");
                ghost.speed = 0.5f; //Remise de la vitesse normale
            }
        }
    }

    // Définit une nouvelle destination aléatoire pour le fantôme.
    private void SetNewRandomDestination()
    {
        randomPos = Random.insideUnitCircle * mRange;
        if (randomPos == lastPos)
        {
            randomPos = Random.insideUnitCircle * mRange;
        }
        ghost.destination = new Vector3(randomPos.x, 0, randomPos.y);
        lastPos = randomPos;


    }

    void SetStopped()
    {
        ghost.isStopped = true;
    }

}
