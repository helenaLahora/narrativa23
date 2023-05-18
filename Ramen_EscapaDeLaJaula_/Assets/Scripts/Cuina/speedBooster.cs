using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedBooster : MonoBehaviour
{
    public float speedMultiplier = 2f; // Factor de multiplicación de velocidad

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("El jugador ha entrado en el collider.");

            // Obtener el componente Rigidbody del jugador
            Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();

            if (playerRigidbody != null)
            {
                // Aumentar la velocidad del jugador
                playerRigidbody.velocity *= speedMultiplier;

                Debug.Log("Se ha aumentado la velocidad del jugador.");
            }
        }
    }
}
