using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    private int damageCounter  = 0;
    public float pushForce = 5;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hola");
            if (EventHandler.Variables[Variable.bolaEjercicio] > 0)
            {
                Debug.Log("damaged");
                damageCounter++;
                if (damageCounter >= 3)
                {

                    EventHandler.Variables[Variable.bolaEjercicio]  = 0;
                    
                    other.gameObject.transform.Translate(Vector3.back * pushForce);

                }             
            }
            else
            {
                // reset game
            }
        }
    }
}
