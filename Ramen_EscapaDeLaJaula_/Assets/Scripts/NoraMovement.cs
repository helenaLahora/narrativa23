using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoraMovement : MonoBehaviour
{
    [SerializeField] private OpenDoor od;

    public Transform[] wayPoints;
    private int currentWayPoint = 0;
    public float minDistance = 15f;
    public float speed = 0;
    private Quaternion ogRotation;
    private Vector3 currentTargetPosition => wayPoints[currentWayPoint].position;
    private bool aux = false;
    [HideInInspector] public float cont = 0;

    [HideInInspector] public float actualTime = 0;
    public float time;
    [HideInInspector] public bool patrol;
    private float fovDistanceIn = 0;
    private float fovDistanceOut = 12;
    void Start()
    {
        ogRotation = transform.rotation;
    }

	private void FixedUpdate()
	{
        actualTime += Time.fixedDeltaTime;
        if (actualTime >= time)
		{
            patrol = true;
		}

        if (patrol)
        {
            if (od.noraMove)
            {
                if (ReachedWayPoint())
                {
                    if (currentTargetPosition == wayPoints[wayPoints.Length - 2].position)
                    {
                        GetComponent<PlayerInFov>().distance = fovDistanceOut;
                    }
                    else
                    {
                        GetComponent<PlayerInFov>().distance = fovDistanceIn;
                    }
                    ChangeWayPoint();
                }

                if (!aux)
                {
                    CheckRb();
                    Move();
                   
                }
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

    private bool ReachedWayPoint()
    {
        if (Vector3.Distance(transform.position, currentTargetPosition) <= minDistance)
        {
            StartCoroutine(Wait());
        }
        return Vector3.Distance(transform.position, currentTargetPosition) <= minDistance;
    }

    private void ChangeWayPoint()
    {
        currentWayPoint++;
        currentWayPoint = currentWayPoint % wayPoints.Length;
        cont++;
    }
    private void Move()
    {
        transform.LookAt(new Vector3(currentTargetPosition.x, transform.position.y, currentTargetPosition.z));
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
