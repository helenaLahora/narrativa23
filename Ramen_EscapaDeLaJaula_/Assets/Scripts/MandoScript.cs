using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MandoScript : MonoBehaviour
{
    [SerializeField] private TeleChange teleChange;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            teleChange.ResetMat();
        }
    }
}
