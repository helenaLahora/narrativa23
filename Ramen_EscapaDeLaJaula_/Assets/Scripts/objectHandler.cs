using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class objectHandler : MonoBehaviour
{
    private UIDocument UI;
    public Texture2D[] calcetin;
    public Texture2D[] peine;
    public Texture2D[] pelota;


    // Start is called before the first frame update
    void Start()
    {
        UI = GetComponent<UIDocument>();
    }

    // Update is called once per frame
    void Update()
    {
        UI.rootVisualElement.Q<Label>("cantidadMonedas").text = EventHandler.Variables[Variable.coin].ToString();
        if (EventHandler.Variables[Variable.collectedObjects] > 0)
        {
            if (GameObject.Find("calcetin") != null)
            {
                
                UI.rootVisualElement.Q<VisualElement>("calcetin").style.backgroundImage = calcetin[0];
            }
            else
            {
                UI.rootVisualElement.Q<VisualElement>("calcetin").style.backgroundImage = calcetin[1];
            }
            if (GameObject.Find("peineLeo") != null)
            {
                UI.rootVisualElement.Q<VisualElement>("peine").style.backgroundImage = peine[0];

            }
           else
            {
                UI.rootVisualElement.Q<VisualElement>("peine").style.backgroundImage = peine[1];
            }
            
        }
        if (EventHandler.Variables[Variable.bolaEjercicio] > 0)
        {
            UI.rootVisualElement.Q<VisualElement>("bola").style.backgroundImage = pelota[1];

        }
        else
        {
            UI.rootVisualElement.Q<VisualElement>("bola").style.backgroundImage = pelota[0];

        }
        Debug.Log(EventHandler.Variables[Variable.collectedObjects]);
    }
}
