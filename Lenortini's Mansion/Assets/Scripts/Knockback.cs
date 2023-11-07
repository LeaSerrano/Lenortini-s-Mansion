using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    // Pour le recul du joueur après collision
    bool isKnockback = false;
    float knockbackTime = 0f; // Durée du knockback en secondes
    float knockbackSpeed = 10f; // Vitesse du knockback
    float jumpForce = 3f; // Force du saut (pendant le knockback)

    void Start()
    {
        
    }

    void Update()
    {
        if (isKnockback)
        {
            transform.position += (-transform.forward * knockbackSpeed * Time.deltaTime);

            if (knockbackTime > 0.2f)
            {
                // ajout d'un saut pour donner un effet de projection en l'air pendant le recul
                transform.position += Vector3.up * jumpForce * Time.deltaTime;
            }

            knockbackTime -= Time.deltaTime;
            if (knockbackTime <= 0)
            {
                isKnockback = false;
            }
        }
    }

    public void ApplyKnockback(float time)
    {
        knockbackTime = time;
        isKnockback = true;
    }
}
