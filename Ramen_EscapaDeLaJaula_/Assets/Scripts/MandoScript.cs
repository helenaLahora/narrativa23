using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MandoScript : MonoBehaviour
{
    [SerializeField] private TeleChange teleChange;
    private bool interacted = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && interacted)
        {
            teleChange.ResetMat();
            interacted = false;
        }
    }
    public void OnInteract()
    {
        interacted = true;
    }
}
