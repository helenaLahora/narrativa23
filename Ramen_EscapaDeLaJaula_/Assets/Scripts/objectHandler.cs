using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Video;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class objectHandler : MonoBehaviour
{
    public GameObject uiPrefab;
    private GameObject uiInstance;
    private UIHANDLE uiHandle;
    private UIDocument UI;
    public Texture2D[] queso;
    public Texture2D[] salchicha;
    public Texture2D[] hueso;
    public Texture2D[] pelota;
    public float tiempoMuerte = 30;
    private float segundos = 60;
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        UI = GetComponent<UIDocument>();
        StartCoroutine(RestarSecs());
    }

   
    private IEnumerator RestarSecs()
    {
        while (tiempoMuerte >= 0)
        {
            
            yield return new WaitForSeconds(1);
            Debug.Log(segundos);
            Debug.Log(tiempoMuerte);
            if (!player.GetComponent<PlayerMovement>().menu) 
            {
                
                if (segundos == 0 && tiempoMuerte>0)
                {
                    

                    segundos = 60;                    
                    tiempoMuerte--;
                    
                    
                }
                else if (tiempoMuerte == 0 && segundos == 0)
                {
                    EventHandler.Variables[Variable.final_happy] = 1;
                    uiInstance = Instantiate(uiPrefab);
                    uiHandle = uiInstance.GetComponent<UIHANDLE>();
                    uiHandle.StartEvent("Evento_TiempoAcabado", player);
                   
                }                    
                    segundos--;
                
            }

        }


    }

    // Update is called once per frame
    void Update()
    {

        UI.rootVisualElement.Q<Label>("cantidadMonedas").text = EventHandler.Variables[Variable.coin].ToString();
        
            if (EventHandler.Variables[Variable.rata_cheese] > 0)
            {                
                UI.rootVisualElement.Q<VisualElement>("queso").style.backgroundImage = queso[0];
            }
            else
            {
                UI.rootVisualElement.Q<VisualElement>("queso").style.backgroundImage = queso[1];
            }
            if (EventHandler.Variables[Variable.salchicha] > 0)
            {
                UI.rootVisualElement.Q<VisualElement>("salchicha").style.backgroundImage = salchicha[0];

            }
           else
            {
                UI.rootVisualElement.Q<VisualElement>("salchicha").style.backgroundImage = salchicha[1];
            }
            if (EventHandler.Variables[Variable.hueso] > 0)
            {
                UI.rootVisualElement.Q<VisualElement>("hueso").style.backgroundImage = hueso[0];
            }
           else
            {
                UI.rootVisualElement.Q<VisualElement>("hueso").style.backgroundImage = hueso[1];
            }
            
        
        if (EventHandler.Variables[Variable.bolaEjercicio] > 0)
        {
            UI.rootVisualElement.Q<VisualElement>("bola").style.backgroundImage = pelota[1];

        }
        else
        {
            UI.rootVisualElement.Q<VisualElement>("bola").style.backgroundImage = pelota[0];

        }
        UI.rootVisualElement.Q<Label>("tiempo").text = string.Empty;
        UI.rootVisualElement.Q<Label>("tiempo").text =tiempoMuerte.ToString()+" : "+ segundos.ToString() +" min";
        EventHandler.Variables[Variable.temporizador] = (int)tiempoMuerte;
    }
}
