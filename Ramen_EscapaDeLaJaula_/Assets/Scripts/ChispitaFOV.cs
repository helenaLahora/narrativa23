using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChispitaFOV :MonoBehaviour
{
    [SerializeField] private Transform player;
    private float FOV = 135;
    public float distance = 5.0f;
    public Transform castPoint;
    [HideInInspector] public bool persuing = false;
    private void Start()
    {
    }

    void Update()
    {
        persuing = CheckVariables();
                    
    }

    public bool CheckVariables()
    {
        if (isInRange())
        {
            if (IsSeen())
            {
                if (!blocked())
                {
                    if (CanSeeRamen())
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            return false;
        }
        return false;
    }
  

    private bool CanSeeRamen()
    {
        if (Physics.Raycast(castPoint.position, Vector3.forward, distance , LayerMask.NameToLayer("Ramen")))
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
