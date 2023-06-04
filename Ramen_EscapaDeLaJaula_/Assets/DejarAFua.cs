using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DejarAFua : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogoFua;
    [SerializeField] private GameObject fuaGO;
    private bool isInRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogoFua.gameObject.SetActive(true);
            isInRange = true;   
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogoFua.gameObject.SetActive(false);
            isInRange = false;
        }
    }
    public void OnInteract()
    {
        
        if (isInRange)
        {
            
            EventHandler.Variables[Variable.sigueARamen] = 0;
            Debug.Log("Hola");
            fuaGO.GetComponent<FuaVaConMadre>().fuaIsFollowing = false;
            
            fuaGO.transform.position = transform.position;
            fuaGO.transform.rotation = transform.rotation;
        }
    }
}
