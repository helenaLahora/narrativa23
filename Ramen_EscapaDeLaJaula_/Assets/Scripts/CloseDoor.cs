using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    [SerializeField] private Transform pivot;
    [SerializeField] private OpenDoor od;
    public float angle;
    [SerializeField] private float tiempo;
    [SerializeField] private NoraMovement nm;
    private bool patrolDone;


    void Update()
    {
        if (patrolDone)
        {
            nm.cont = 0;
            nm.patrol = false;
            patrolDone = false;
            od.opennedOnce = false;
            od.canOpen = true;
            nm.actualTime = 0;
            StartCoroutine(Wait());
        }

        if (nm.cont == 5)
        {
            patrolDone = true;
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(DoorClose(tiempo));
        yield return new WaitForSeconds(1);
        od.noraMove = false;
    }

    private IEnumerator DoorClose(float time)
    {
        float elapsed = 0;

        while (elapsed < time)
        {
            transform.RotateAround(pivot.position, Vector3.up, angle * Time.deltaTime);
            yield return null;
            elapsed += Time.deltaTime;
        }
    }
}
