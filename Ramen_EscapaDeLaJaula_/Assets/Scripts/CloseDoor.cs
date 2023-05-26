using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
[SerializeField] private Transform pivot;
    private bool canOpen = true;
    [HideInInspector] public bool noraMove;
    private bool doorIsOpenned;
    public float angle;
    [SerializeField] private float tiempo;


    void Update()
    {
        if (canOpen)
        {
            StartCoroutine(Wait());

        }

        
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        StartCoroutine(DoorClose(tiempo));
    }

    private IEnumerator DoorClose(float time)
    {
        float elapsed = 0;

        while (elapsed<time)
        {
            transform.RotateAround(pivot.position, Vector3.up, angle * Time.deltaTime);
            yield return null;
            elapsed += Time.deltaTime;
        }

        doorIsOpenned = true;
    }
}
