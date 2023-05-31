using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoraFov : MonoBehaviour
{
	[SerializeField] private Transform player;
	private float FOV = 100;
    [SerializeField] private float distance = 5.0f;
    public Transform castPoint;
    private bool killed = false;
    [SerializeField] private GameObject uiPrefab;
    private GameObject uiInstance;
    private UIHANDLE uiHandle;  
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
                        if (!GameObject.FindWithTag("UI") && !killed)
                        {
                            EventHandler.Variables[Variable.final_happy] = 1;
                            uiInstance = Instantiate(uiPrefab);
                            uiHandle = uiInstance.GetComponent<UIHANDLE>();
                            uiHandle.StartEvent("Evento_NoraPillaRamen", player.gameObject);
                            killed = true;
                        }
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
