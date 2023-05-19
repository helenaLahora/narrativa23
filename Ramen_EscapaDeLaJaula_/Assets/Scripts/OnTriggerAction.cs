using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OnTriggerAction : MonoBehaviour
{
    private bool playerIn = false;
    private bool rotated = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIn = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIn = false;
        }
    }

    private void OnInteract()
    {
        if (EventHandler.Variables[Variable.motas_completedmission] > 0)
        {
            if (playerIn && !rotated)
            {
                transform.Rotate(new Vector3(0, 90, 0));
                rotated = true;
            }
            else if (rotated && playerIn)
            {
                transform.Rotate(new Vector3(0, -90, 0));
                rotated = false;
            }
        }
       
    }

}
