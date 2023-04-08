using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class EventHandler : MonoBehaviour
{
    public static Dictionary<Variable, int> Variables = new Dictionary<Variable, int>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (Variable variable in Enum.GetValues(typeof(Variable)))
        {
            Variables.Add(variable, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
   
}
