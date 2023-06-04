using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    [SerializeField]private Transform player;
    private int damageCounter  = 0;
    public float pushForce = 5;
    private Vector3 startingPosition = Vector3.zero;
    [SerializeField] private float pushDuration = 1.0f;
    private void Awake()
    {
        startingPosition = player.position; 
    }
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (EventHandler.Variables[Variable.bolaEjercicio] > 0)
            {
                damageCounter++;
                if (damageCounter >= 3)
                {

                    EventHandler.Variables[Variable.bolaEjercicio]  = 0;
                    StartCoroutine(Empujasion(other));
                    

                }             
            }
            else
            {
                // reset game
                player.position = startingPosition;
            }
        }
    }
    private IEnumerator Empujasion(Collider other)
    {
        float tiempo = 0;
        while (tiempo < pushDuration)
        {
            other.gameObject.transform.Translate(Vector3.back * pushForce);
            tiempo += Time.deltaTime;
            yield return null;
            
        }
        
    }
}
