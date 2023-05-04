using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerDetection : MonoBehaviour
{
    public bool playerdetected = false;
    public SphereCollider Collider;
    public bool talk = false;
    private UIHANDLE uiHandle;
    public GameObject uiPrefab;
    private GameObject uiInstance;
    private GameObject player;
    public string nombreEvento;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {



    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerdetected = true;
            player = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {

            playerdetected = false;
        
    }
    private void OnTalk()
    {
        if (playerdetected)
        {
            talk = true;
            if(uiInstance == null)
            {
                uiInstance = Instantiate(uiPrefab);
                uiHandle = uiInstance.GetComponent<UIHANDLE>();
                uiHandle.StartEvent(nombreEvento, player);
            }
        }
    }
}
