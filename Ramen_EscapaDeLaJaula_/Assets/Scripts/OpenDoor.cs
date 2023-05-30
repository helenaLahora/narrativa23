using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private Transform pivot;
    [HideInInspector] public bool canOpen = true;
    [HideInInspector] public bool noraMove;
    public float angle;
    [SerializeField] private float tiempo;
    [SerializeField] private NoraMovement nm;
    [HideInInspector] public bool opennedOnce;

    void Update()
    {
        if (canOpen && nm.patrol && !opennedOnce)
        {
            opennedOnce = true;
            StartCoroutine(MoveNora());
        }
    }

    private IEnumerator MoveNora()
    {
        noraMove = true;
        canOpen = false;
        StartCoroutine(DoorOpen(tiempo));
        yield return new WaitForSeconds(1);
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
        canOpen = false;
    }
}
