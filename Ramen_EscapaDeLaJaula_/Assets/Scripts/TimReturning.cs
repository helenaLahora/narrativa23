using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimReturning : MonoBehaviour
{
    public Transform[] wayPoints;
    private int currentWayPoint = 0;
    public float minDistance = 15f;
    public float speed = 0;
    private bool isReturning;
    private Quaternion ogRotation;
    private Vector3 currentTargetPosition => wayPoints[currentWayPoint].position;
    private bool aux = false;
    [SerializeField] PlayerDetection pd;

    private void Start()
    {
        ogRotation = transform.rotation;

    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(pd.talk);
        if (!pd.talk)
        {
            if (ReachedWayPoint())
            {
                ChangeWayPoint();
            }

            if (!aux)
            {
                CheckRb();
                Move();
            }
        }
    }

    private IEnumerator Wait()
    {
        aux = true;
        yield return new WaitForSeconds(2);
        aux = false;
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
        if (Vector3.Distance(transform.position, currentTargetPosition) <= minDistance)
        {
            StartCoroutine(Wait());
        }
        return Vector3.Distance(transform.position, currentTargetPosition) <= minDistance;
    }

    //Cambia al siguiete wayPoint
    private void ChangeWayPoint()
    {
       if (currentWayPoint < wayPoints.Length)
        {
            currentWayPoint++;

        }


    }
    private void Move()
    {
        transform.LookAt(new Vector3(currentTargetPosition.x, transform.position.y, currentTargetPosition.z));
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

}
