using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeObject : MonoBehaviour
{
    public bool playerDetectedObject = false;

    public SphereCollider SphereCollider;

    [SerializeField] private Variable variable;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerDetectedObject = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerDetectedObject = false;

        }
    }

    public void OnInteract()
	{
        if (playerDetectedObject)
		{
            EventHandler.Variables[variable]++;
            Destroy(gameObject); 
		}
	}

}
