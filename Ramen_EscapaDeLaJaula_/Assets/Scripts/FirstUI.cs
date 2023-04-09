using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FirstUI : MonoBehaviour
{
    public GameObject uiPrefab;
    private GameObject uiInstance;
    private UIHANDLE uiHandle;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        uiInstance = Instantiate(uiPrefab);
        uiHandle =  uiInstance.GetComponent<UIHANDLE>();
        uiHandle.StartEvent("Evento_Empezar", player);

    }


}
