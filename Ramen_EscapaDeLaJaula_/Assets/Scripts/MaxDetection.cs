using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxDetection : MonoBehaviour
{
    [HideInInspector] public bool ramenDetected = false;
    [SerializeField] private Transform max;
    [SerializeField] private Transform player;
    private DealDamage dealDamageScript;
    private float auxY;
    private float distance = 10;
    private void Start()
    {
        auxY = max.position.y;
        dealDamageScript = GetComponent<DealDamage>();
    }
    private void Update()
    {
        if (ramenDetected)
        {
            ChaseRamen();
        }
    }

    private void ChaseRamen()
    {
        Vector3 diference;
          diference.x  = max.position.x - player.position.x;
          diference.z = max.position.z - player.position.z;
        max.LookAt(new Vector3(player.position.x, 0, player.position.z));
        max.Translate(new Vector3(diference.x, 0, diference.z) * Time.deltaTime);
       if (Vector3.Distance(max.position, player.position) < distance && !GameObject.FindGameObjectWithTag("UI"))
        {
            dealDamageScript.enabled = true;
            player.position = dealDamageScript.startPosition;
           
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ramenDetected = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ramenDetected = false;
        }
    }
}
