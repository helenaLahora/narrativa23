using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    // Start is called before the first frame update
    public bool playerdetected = false;
    public SphereCollider Collider;
    public bool talk = false;
    public UIHANDLE uiHandle;
    private int dialogueCounter = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (!talk)
        //{
        //    uiHandle.UI.enabled = false;
        //}




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
        if (playerdetected)
        {
            talk = true;
            uiHandle.UI.enabled = true;
            dialogueCounter++;
            uiHandle.StartDialogue(gameObject.name + dialogueCounter);

        }
        Debug.Log("Hola");

    }
}
