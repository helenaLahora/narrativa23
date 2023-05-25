using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubosJaula : MonoBehaviour
{
    public Transform player; // Referencia al objeto del jugador
    public Transform waypoint; // Referencia al objeto del waypoint

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            TeleportPlayer();
        }
    }

    private void TeleportPlayer()
    {
        player.position = waypoint.position;
        player.rotation = waypoint.rotation;
    }
}