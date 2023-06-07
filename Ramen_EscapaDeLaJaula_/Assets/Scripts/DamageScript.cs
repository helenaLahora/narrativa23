using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DamageScript : MonoBehaviour
{
    [SerializeField]private Transform player;
    private int damageCounter  = 0;
    public float pushForce = 2;
    private Vector3 startingPosition = Vector3.zero;
    [SerializeField] private float pushDuration = 1f;
    [SerializeField] private Image damageImage;
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

        damageImage.color = new Color(damageImage.color.r, damageImage.color.g, damageImage.color.b, 0);
        float tiempo = 0;
        float alpha = 0f;
        while (tiempo < pushDuration)
        {
            
            other.gameObject.transform.Translate(Vector3.back * pushForce);
            tiempo += Time.deltaTime;
            damageImage.color = new Color(damageImage.color.r, damageImage.color.g, damageImage.color.b, alpha);
            yield return new WaitForEndOfFrame();
            alpha += 0.1f;

        }
        while (alpha >= 0f)
        {
            damageImage.color = new Color(damageImage.color.r, damageImage.color.g, damageImage.color.b, alpha);
            yield return new WaitForEndOfFrame();
            alpha -= 0.1f;
        }
        
    }
}
