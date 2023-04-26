using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField] private GameObject particlePrefab;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Instantiate(particlePrefab, transform.position, Quaternion.identity); 
            Destroy(this.gameObject);
            EventHandler.Variables[Variable.coin]++;
        }
    }

}
