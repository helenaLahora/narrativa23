using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimHandler : MonoBehaviour
{
    private patrolingNPC patrolingScript;
    private TimReturning returningScript;
    // Start is called before the first frame update
    void Start()
    {
        patrolingScript = GetComponent<patrolingNPC>();
        returningScript = GetComponent<TimReturning>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckVariables();
    }
    void CheckVariables()
    {
        if (EventHandler.Variables[Variable.vuelveConMama] > 0)
        {
            patrolingScript.enabled = false;
            returningScript.enabled = true;
        }
        else
        {
            patrolingScript.enabled = true;
            returningScript.enabled = false;
        }
    }
}

