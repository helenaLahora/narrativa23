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
    private void Start()
    {
        energy = 100f;
        patrollingScript = GetComponent<PatrollingScript>();    
        chispasHandler = GetComponent<ChispasHandler>();    
    }
    void Update()
    {
        EnableScripts();
        if (GetComponent<ChispitaFOV>().persuing)
        {
            Vector3 enemy = transform.position;
            Vector3 distance = enemy - new Vector3(player.transform.position.x, enemy.y, player.transform.position.z);
            transform.Translate(distance - Vector3.forward);
            
        }
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
