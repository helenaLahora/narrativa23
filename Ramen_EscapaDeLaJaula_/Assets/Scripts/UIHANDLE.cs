using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements; 
public class UIHANDLE : MonoBehaviour
{
    private UIDocument UI;
    public Label label, nombre;
    public EventManager eventManager;
    private Evento currentEvent;
    private Dialogo currentDialogue;
    public float textSpeed =1f;
    public VisualTreeAsset[] visualTreeAssets;
    private Coroutine rutina;
    private Nodo currentNodo;
    private GameObject player;


    // Start is called before the first frame update
    private void Awake()
    {
        UI = GetComponent<UIDocument>();

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartEvent(string identifier, GameObject playerGameObject)
    {

        player = playerGameObject;
        currentEvent = Array.Find(eventManager.eventos, e => e.identifier == identifier);
        currentDialogue = currentEvent.dialogos[0];
        currentNodo = currentDialogue.nodos[0];
        rutina = StartCoroutine(TypeLine());
                
    }
    IEnumerator TypeLine()
    {
       
        int index=0;
        player.GetComponent<CamMovement>().enabled = false;
        player.GetComponent<PlayerInput>().DeactivateInput();
        
        
        if (UI != null)
        {

            switch (currentNodo.tipoNodo)
            {
                case TipoNodo.conversacion:
                    UI.visualTreeAsset = visualTreeAssets[0];

                    break;

                case TipoNodo.presentacion:
                    UI.visualTreeAsset = visualTreeAssets[1];

                    break;

                case TipoNodo.eleccion:
                    UI.visualTreeAsset = visualTreeAssets[2];

                    break;


            }
            label = UI.rootVisualElement.Q<Label>("contenido");
            nombre = UI.rootVisualElement.Q<Label>("nombre");
            foreach (Boton boton in currentNodo.botones)
            {
                Button button = new Button();
                button.text = boton.nombre;
                button.AddToClassList(boton.tipoBoton == TipoBoton.Eleccion ? "boton-secundario-pequeno" : "boton-primario-pequeno");
                UI.rootVisualElement.Q<VisualElement>(boton.tipoBoton == TipoBoton.Eleccion ? "opciones" : "botones").Add(button);
                switch (boton.tipoBoton)
                {
                    case TipoBoton.Salir:
                        button.clickable.clicked += () => Destroy(gameObject);
                        button.clickable.clicked += () => player.GetComponent<CamMovement>().enabled = true;
                        button.clickable.clicked += () => player.GetComponent<PlayerInput>().ActivateInput(); 
                        break;
                    case TipoBoton.Condicion:
                        if (boton.condiciones.Length > 0)
                        {
                            Debug.Log(boton.condiciones);
                            foreach (Condicion condicion in boton.condiciones)
                            {
                                bool resultado = false;
                                switch (condicion.operador) 
                                {

                                    case Operador.igual:
                                        resultado = EventHandler.Variables[condicion.variable] == condicion.valor;
                                        break;
                                    case Operador.diferente:
                                        resultado = EventHandler.Variables[condicion.variable] != condicion.valor;
                                        break;
                                    case Operador.mayor:
                                        resultado = EventHandler.Variables[condicion.variable] > condicion.valor;
                                        break;
                                    case Operador.menor:
                                        resultado = EventHandler.Variables[condicion.variable] < condicion.valor;
                                        break;
                                    case Operador.mayor_igual:
                                        resultado = EventHandler.Variables[condicion.variable] >= condicion.valor;
                                        break;
                                    case Operador.menor_igual:
                                        resultado = EventHandler.Variables[condicion.variable] <= condicion.valor;
                                        break;
                                }
                                if (resultado)
                                {
                                    button.clickable.clicked += () => AsignarDialogo(condicion.dialogoTrue);
                                    break;
                                }
                                else
                                {
                                    if (boton.condiciones.Last() == condicion)
                                    {
                                        button.clickable.clicked += () => AsignarDialogo(condicion.dialogoFalse);

                                    }
                                }
                            }
                        }
                        break;
                    case TipoBoton.Eleccion:
                        button.clickable.clicked += () => AsignarDialogo(boton.siguienteDialogo);                   
                        break;
                    case TipoBoton.Continuar:
                        index = Array.IndexOf(currentDialogue.nodos, currentNodo) + 1;
                        if (index < currentDialogue.nodos.Length)
                        {

                            button.clickable.clicked += () => AsignarNodo(index);
                        }
                        break;
                    case TipoBoton.Volver:
                        index = Array.IndexOf(currentDialogue.nodos, currentNodo) -1 ;
                        if (index > 0)
                        {

                            button.clickable.clicked += () => AsignarNodo(index);
                        }
                        break;

                }
                if (boton.accion.Length > 0)
                {
                    foreach (Accion accion in boton.accion)
                    {

                        button.clickable.clicked += () => EventHandler.Variables[accion.variable] += accion.valor;
                        Debug.Log(EventHandler.Variables[accion.variable]);
                    }
                }
        }
            if (currentNodo.esPersonaje)
            {
                nombre.text = currentNodo.personaje;

            }
            else
            {
                nombre.style.display = DisplayStyle.None;
            }
            label.text = string.Empty;

            foreach (char c in currentNodo.texto.ToCharArray())
            {
                label.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }
    }
    public void AsignarDialogo(string identifier)
    {
        StopCoroutine(rutina);
        currentDialogue = Array.Find(currentEvent.dialogos, e => e.identifier == identifier);
        currentNodo = currentDialogue.nodos[0];
        StartCoroutine(TypeLine());
    }
    public void AsignarNodo(int index)
    {
        StopCoroutine(rutina);
        currentNodo = currentDialogue.nodos[index];
        StartCoroutine(TypeLine());
    }
}   
