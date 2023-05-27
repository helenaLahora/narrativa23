using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScriptHandler : MonoBehaviour
{
    private patrolingNPC patrollingScript;
    private ReturningScript returnScript;
    private void Start()
    {
       patrollingScript = GetComponent<patrolingNPC>();
        returnScript = GetComponent<ReturningScript>(); 
    }
    // Update is called once per frame
    void Update()
    {
        CheckVariable();
    }

    private void CheckVariable()
    {
        if (EventHandler.Variables[Variable.vuelveConMama]>0)
        {
            returnScript.enabled = true;
            patrollingScript.enabled = false;
        }
        else
        {
            returnScript.enabled = false;
            patrollingScript.enabled = true;
        }
    }
}
