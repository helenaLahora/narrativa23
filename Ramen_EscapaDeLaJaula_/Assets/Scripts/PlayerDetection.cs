using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Video;

public class PlayerDetection : MonoBehaviour
{
    [HideInInspector]public bool playerdetected = false;
    [HideInInspector] public bool talk = false;
    private UIHANDLE uiHandle;
    public GameObject uiPrefab;
    private GameObject uiInstance;
    private GameObject player;
    public string nombreEvento;
    private SpawnParticles spawner;
    private GameObject chispa;
    private float ogSpeed = 0;

    
    private PatrollingScript patrollingScript;

    void Start()
    {
        if ( transform.gameObject.name == "Marga")
        {
            spawner = transform.gameObject.GetComponent<SpawnParticles>();

        }
        chispa = GameObject.FindGameObjectWithTag("Chispa");


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
        chispa.GetComponent<PatrollingScript>().speed = ogSpeed;

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
                ogSpeed = chispa.GetComponent<PatrollingScript>().speed;
                chispa.GetComponent<PatrollingScript>().speed = 0;
            }
            if (spawner != null)
            {
                
                spawner.SpawnPS();
            }
          

        }
    }
}
