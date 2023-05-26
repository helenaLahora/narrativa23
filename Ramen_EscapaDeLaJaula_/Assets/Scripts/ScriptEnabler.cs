using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptEnabler : MonoBehaviour
{
    public float energy;
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
        if (EnergyCheck())
        {
            chispasHandler.enabled = false;
            patrollingScript.enabled = true;
            if (!startLoosing)
            {
               StartCoroutine( chispasHandler.EnergyEditor(-1));
                startLoosing = true;
            }
                Debug.Log(energy);
        }
        else
        {
            
            patrollingScript.enabled = false;
            chispasHandler.enabled = true; 
            
        }
    }
    private bool EnergyCheck()
    {
        return energy >= 10;
    }
}
