using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoraFov : MonoBehaviour
{
	[SerializeField] private GameObject player;
	private float FOV = 100;
    [SerializeField] private float distance = 5.0f;
    public Transform castPoint;
    public Transform ramenSpawnPoint;

    private void Start()
	{

	}

    void Update()
    {
        if (isInRange())
        {
            if (IsSeen())
            {
                if (!blocked())
				{
                    if (CanSeeRamen())
					{
                        Debug.Log("aaa");
                        player.transform.position = ramenSpawnPoint.position;
                    }
				}
			}
        }
    }

	private bool CanSeeRamen()
	{
        if (Physics.Raycast(castPoint.position, Vector3.forward, distance, LayerMask.NameToLayer("Ramen")))
        {
            return true;
        }

        return false;
    }

	private bool blocked()
    {
        if (Physics.Raycast(castPoint.position, Vector3.forward, distance, default))
        {
            return true;
        }

        return false;
    }

    private bool IsSeen()
    {
        float halfFOV = FOV / 2;
        Vector3 a = transform.forward;
        Vector3 b = player.transform.position - transform.position;
        float playerAngle = Vector3.Angle(a, b);
        return playerAngle <= halfFOV;
    }

    private bool isInRange()
    {
        return Vector3.Distance(transform.position, player.transform.position) < distance;
    }
}
