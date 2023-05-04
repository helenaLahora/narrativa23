using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingScript : MonoBehaviour
{
    public Transform[] wayPoints; 
    private int currentWayPoint = 0;
    public float minDistance = 15f;
    [HideInInspector] public float speed = 0;
    private bool isReturning;
    private Quaternion ogRotation;
    private Vector3 currentTargetPosition => wayPoints[currentWayPoint].position;

    private void Start()
    {
        ogRotation = transform.rotation;
    }
    // Update is called once per frame
    void Update()
    {
        if (ReachedWayPoint())
        {
            ChangeWayPoint();
        }
        CheckRb();
        Move();
    }

    private void CheckRb()
    {
        if (transform.rotation.x != 0 && transform.rotation.z != 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,ogRotation,Time.deltaTime*speed);
        }
    }

    //Checkea si est� cerca o encima del wayPoint
    private bool ReachedWayPoint()
    {
        return Vector3.Distance(transform.position, currentTargetPosition) <= minDistance;
    }

    //Cambia al siguiete wayPoint
    private void ChangeWayPoint()
    {
        if (currentWayPoint >= wayPoints.Length - 1 || isReturning)
        {
            currentWayPoint--;
            if (currentWayPoint <= 0)
            {
                isReturning = false;
            }

        }
        else
        {
            currentWayPoint++;
            if (currentWayPoint >= wayPoints.Length - 1)// si se establece a 0 se hace loop de la ruta, si se hace -- vuelve hacia atras :)
            {
                isReturning = true;
            }
            //currentWayPoint = currentWayPoint % wayPoints[Length]; para bucle
        }
    }
    private void Move()
    {
        transform.LookAt(new Vector3 (currentTargetPosition.x, transform.position.y, currentTargetPosition.z));
        transform.Translate(Vector3.forward * speed * Time.deltaTime);


    }

}
