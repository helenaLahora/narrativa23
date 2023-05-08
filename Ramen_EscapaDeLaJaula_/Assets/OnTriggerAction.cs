using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerAction : MonoBehaviour
{
    private bool playerIn = false;
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
        if (playerIn)
        {
            transform.Rotate(new Vector3(0, 90, 0));
        }
    }

}
