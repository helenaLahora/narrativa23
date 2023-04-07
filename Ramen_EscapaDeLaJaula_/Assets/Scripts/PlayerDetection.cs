using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    // Start is called before the first frame update
    public bool playerdetected = false;
    public SphereCollider Collider;
    public bool talk = false;
    private UIHANDLE uiHandle;
    public GameObject uiPrefab;
    private GameObject uiInstance;
    private int dialogueCounter = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {




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
            dialogueCounter++;
            if(uiInstance == null)
            {
                uiInstance = Instantiate(uiPrefab);
                uiHandle = uiInstance.GetComponent<UIHANDLE>();
                uiHandle.StartDialogue(gameObject.name + dialogueCounter);
            }


        }
        else
        {
            dialogueCounter = 0;
        }

    }
}
