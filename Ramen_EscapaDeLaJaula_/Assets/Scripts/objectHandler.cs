using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class objectHandler : MonoBehaviour
{
    private UIDocument UI;
    // Start is called before the first frame update
    void Start()
    {
        UI = GetComponent<UIDocument>();
    }

    // Update is called once per frame
    void Update()
    {
        UI.rootVisualElement.Q<Label>("cantidadMonedas").text = EventHandler.Variables[Variable.coin].ToString();
    }
}
