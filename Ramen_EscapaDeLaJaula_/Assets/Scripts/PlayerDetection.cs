using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
    private bool sciptEnabled = false;
    private bool sciptEnabled1 = false;
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
            sciptEnabled = chispa.GetComponent<ChispasHandler>().enabled ;
            sciptEnabled1 =  chispa.GetComponent<PatrollingScript>().enabled ;
        }

    }

    private void OnTriggerExit(Collider other)
    {

        playerdetected = false;
        talk = false;
        chispa.GetComponent<ChispasHandler>().enabled = sciptEnabled;
        chispa.GetComponent<PatrollingScript>().enabled = sciptEnabled1;
        chispa.GetComponent<ScriptEnabler>().enabled = true;

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
                chispa.GetComponent<ChispasHandler>().enabled = false;
                chispa.GetComponent<PatrollingScript>().enabled = false;
                chispa.GetComponent<ScriptEnabler>().enabled = false;
            }
            if (spawner != null)
            {
                
                spawner.SpawnPS();
            }
            
        }
    }
}
