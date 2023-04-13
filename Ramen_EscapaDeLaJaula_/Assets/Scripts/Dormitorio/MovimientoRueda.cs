using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoRueda : MonoBehaviour
{
    public GameObject playerObject;
    public float rotateSpeed = 10f;
    public Vector3 rotationAxis = Vector3.up; // default rotation axis is up

    private bool isPlayerInside = false;

    void FixedUpdate()
    {
        if (isPlayerInside)
        {
            transform.Rotate(rotationAxis, rotateSpeed * Time.fixedDeltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerObject)
        {
            isPlayerInside = true;
            Debug.Log("Player entered wheel collider");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == playerObject)
        {
            isPlayerInside = false;
            Debug.Log("Player exited wheel collider");
        }
    }
}