using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHidder : MonoBehaviour
{
    [SerializeField] private Variable variable;
    [SerializeField] private float valorAComparar;
    void Start()
    {
        
    }

    void Update()
    {
        if (EventHandler.Variables[variable] > valorAComparar)
        {
            Destroy(gameObject);
        }
    }
    
}
