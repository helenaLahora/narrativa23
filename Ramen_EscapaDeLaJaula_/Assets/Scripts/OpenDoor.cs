using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private Transform pivot;
    private bool canOpen = true;
    [HideInInspector] public bool noraMove;
    private bool doorIsOpenned;
    public float angle;
    [SerializeField] private float tiempo;

    void Start()
    {

    }


    void Update()
    {
        if (canOpen)
        {
            StartCoroutine(MoveNora());

        }

        
    }

    private IEnumerator MoveNora()
    {
        noraMove = true;
        canOpen = false;
        yield return new WaitForSeconds(2);
        StartCoroutine(DoorOpen(tiempo));
    }

    private IEnumerator DoorOpen(float time)
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
