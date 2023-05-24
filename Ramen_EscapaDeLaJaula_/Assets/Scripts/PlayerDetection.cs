using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerDetection : MonoBehaviour
{
    [HideInInspector]public bool playerdetected = false;
    public SphereCollider Collider;
    [HideInInspector] public bool talk = false;
    private UIHANDLE uiHandle;
    public GameObject uiPrefab;
    private GameObject uiInstance;
    private GameObject player;
    public string nombreEvento;
    private SpawnParticles spawner;

    void Start()
    {
        if ( transform.gameObject.name == "Marga")
        {
            spawner = transform.gameObject.GetComponent<SpawnParticles>();

        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!talk && spawner != null)
        {
            spawner.DestroyPS();
        }

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
        talk = false;
        
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
            if (spawner != null)
            {
                
                spawner.SpawnPS();
            }
            
        }
    }
}
