using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChispasHandler : MonoBehaviour
{
    [SerializeField] private Transform[] wayPoints;
    [SerializeField] private Transform charger;
    private int currentWayPoint = 0;
    public float minDistance = 15f;
    public float speed = 0;
    private float energy = 0;
    private bool isReturning;
    private Quaternion ogRotation;
    private Vector3 currentTargetPosition => wayPoints[currentWayPoint].position;
    private bool isMoving = true;
    private void Start()
    {
        ogRotation = transform.rotation;

    }

    private IEnumerator EnergyEditor(float value)
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            energy += value;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            if (ReachedWayPoint())
            {
                ChangeWayPoint();
            }
            CheckRb();
            Move();
        }

        if (CheckCharger())
        {
            isMoving = false;
            StartCoroutine(EnergyEditor(1));
            
        }
        if (energy >= 100)
        {
            StopCoroutine(EnergyEditor(1));
            transform.gameObject.GetComponent<PatrollingScript>().enabled = true;
            transform.gameObject.GetComponent<ChispasHandler>().enabled = false;
        }
    }

    private bool CheckCharger()
    {
        return Vector3.Distance(transform.position, charger.position) <= minDistance;
    }

    private bool EnergyCheck()
    {
        return energy > 10;
    }
    private void CheckRb()
    {
        if (transform.rotation.x != 0 && transform.rotation.z != 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, ogRotation, Time.deltaTime * speed);
        }
    }

    //Checkea si est? cerca o encima del wayPoint
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
        transform.LookAt(new Vector3(currentTargetPosition.x, transform.position.y, currentTargetPosition.z));
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }


}
