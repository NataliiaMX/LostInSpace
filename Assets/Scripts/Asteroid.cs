using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private PlayerHealth playerHealth;

    private void OnTriggerEnter(Collider other) 
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.Crash();
        }
        else 
        {
            return;
        }
    }
}
