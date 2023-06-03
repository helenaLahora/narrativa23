using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptEnabler : MonoBehaviour
{
    [SerializeField] private Transform player;
    [HideInInspector]public float energy;
    private PatrollingScript patrollingScript;
    private ChispasHandler chispasHandler;
    private bool startLoosing = false;
    private bool startpersuing = false;
    private void Start()
    {
        energy = 100f;
        patrollingScript = GetComponent<PatrollingScript>();    
        chispasHandler = GetComponent<ChispasHandler>();    
    }
    void Update()
    {
        if (GetComponent<ChispitaFOV>().persuing && !startpersuing)
        {
            startpersuing = true;
            StartCoroutine(PersueRamen());

           
            
        }
        else
        {
            startpersuing = false;
            patrollingScript.speed = 5;
            EnableScripts();
        }        
              
    }

    private IEnumerator PersueRamen()
    {
        patrollingScript.speed = 0;
        chispasHandler.enabled = false;
        patrollingScript.enabled = false;
        while (GetComponent<ChispitaFOV>().persuing)
        {           
            Vector3 distance = new Vector3(player.transform.position.x , transform.position.y, player.transform.position.z ) - transform.position ;
            transform.Translate(distance * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(3);
        
    }

    private void EnableScripts()
    {
        if (EnergyCheck() && !GetComponent<ChispitaFOV>().persuing)
        {
            chispasHandler.enabled = false;
            patrollingScript.enabled = true;
            if (!startLoosing)
            {
                StartCoroutine(chispasHandler.EnergyEditor(-1));
                startLoosing = true;
            }
             
        }
        else if (!EnergyCheck() && energy <= 100 && !GetComponent<ChispitaFOV>().persuing)
        {

            patrollingScript.enabled = false;
            chispasHandler.enabled = true;
            startLoosing = false;
        }
        
    }

    private bool EnergyCheck()
    {
        return energy >= 10;
    }
}
