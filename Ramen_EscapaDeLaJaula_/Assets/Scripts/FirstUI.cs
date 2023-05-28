using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Video;

public class FirstUI : MonoBehaviour
{
    public GameObject uiPrefab;
    private GameObject uiInstance;
    private UIHANDLE uiHandle;
    public GameObject player;
    private bool hasStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!hasStarted)
        {
            uiInstance = Instantiate(uiPrefab);
            uiHandle = uiInstance.GetComponent<UIHANDLE>();
            uiHandle.StartEvent("Evento_Empezar", player);
            hasStarted = true;
        }

        

    }
    private void Update()
    {
    }

    public void Menu()
    {
        if (player.GetComponent<PlayerMovement>().menu)
        {
            uiInstance = Instantiate(uiPrefab);
            uiHandle = uiInstance.GetComponent<UIHANDLE>();
            uiHandle.StartEvent("Evento_Menu", player);
        }

       
    }
   

}
