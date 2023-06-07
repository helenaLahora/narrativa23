using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaDialogo : MonoBehaviour
{
    private bool playerdetected = false;
    private UIHANDLE uiHandle;
    public GameObject uiPrefab;
    private GameObject uiInstance;
    private GameObject player;
    public string nombreEvento;



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerdetected = true;
            player = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        playerdetected = false;

    }

    private void OnInteract()
    {
        if (playerdetected)
        {
            if (uiInstance == null)
            {
                uiInstance = Instantiate(uiPrefab);
                uiHandle = uiInstance.GetComponent<UIHANDLE>();
                uiHandle.StartEvent(nombreEvento, player);

            }           
        }
    }
}
