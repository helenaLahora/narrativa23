using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    // Start is called before the first frame update
    public bool playerdetected = false;
    public SphereCollider Collider;
    public bool talk = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerdetected && talk)
        {
            Debug.Log("Hola");
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerdetected = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {

            playerdetected = false;
        
    }
    private void OnTalk()
    {
        talk = true;
    }
}
