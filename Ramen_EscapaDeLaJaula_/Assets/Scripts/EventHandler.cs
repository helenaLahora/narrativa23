using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class EventHandler : MonoBehaviour
{
    public static Dictionary<Variable, int> Variables = new Dictionary<Variable, int>();
    public GameObject pelota;

    void Awake()
    {
        foreach (Variable variable in Enum.GetValues(typeof(Variable)))
        {
            Variables.Add(variable, 0);
        }
    }

    void Update()
    {
        if (Variables[Variable.bolaEjercicio] > 0)
        {
            pelota.SetActive(true);
        }
        else
        {
            pelota.SetActive(false);
        }
    }
   
}
