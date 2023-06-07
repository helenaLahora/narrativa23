using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [HideInInspector]public Vector3 startPosition = Vector3.zero;
    [SerializeField] private Transform max;
    [SerializeField] private Transform player;
    [SerializeField] private float distance = 10; 
    private void Start()
    {
        startPosition = player.position;
    }
 
    public void Tp()
    {
        Debug.Log(player.position);
        player.position = startPosition;
        Debug.Log(player.position);

    }
}
