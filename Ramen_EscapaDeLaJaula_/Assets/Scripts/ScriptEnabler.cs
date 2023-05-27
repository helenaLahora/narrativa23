using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptEnabler : MonoBehaviour
{
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
    }

    private void EnableScripts()
    {
        if (EnergyCheck())
        {
            chispasHandler.enabled = false;
            patrollingScript.enabled = true;
            if (!startLoosing)
            {
                StartCoroutine(chispasHandler.EnergyEditor(-1));
                startLoosing = true;
            }
        }
        else if (!EnergyCheck() && energy <= 100)
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
