using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNora : MonoBehaviour
{
    private UIHANDLE uiHandle;
    public GameObject uiPrefab;
    private GameObject uiInstance;
    private GameObject player;
    public string nombreEvento;
    private bool noraTalked = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && noraTalked)
        {
            player = other.gameObject;
            uiInstance = Instantiate(uiPrefab);
            uiHandle = uiInstance.GetComponent<UIHANDLE>();
            uiHandle.StartEvent(nombreEvento, player);
            noraTalked = true;
        }
    }
}
