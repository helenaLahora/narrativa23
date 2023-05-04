using System;
using System.Collections;
using System.Linq;
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
    private Nodo currentNodo;
    private GameObject player;
    public GameObject expModo;
    private GameObject cinemachine;
    // Start is called before the first frame update
    private void Awake()
    {
        UI = GetComponent<UIDocument>();
        expModo = GameObject.Find("ExpModo");
        cinemachine = GameObject.FindGameObjectWithTag("Cine");
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
        cinemachine.SetActive(false);
        expModo.GetComponent<UIDocument>().rootVisualElement.style.display = DisplayStyle.None;
        player = playerGameObject;
        currentEvent = Array.Find(eventManager.eventos, e => e.identifier == identifier);
        currentDialogue = currentEvent.dialogos[0];
        currentNodo = currentDialogue.nodos[0];
        TypeLine();
                
    }
    void TypeLine()
    {
       
        int index=0;
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
                case TipoNodo.historiaPresentacion:
                    UI.visualTreeAsset= visualTreeAssets[3];
                    break;
                case TipoNodo.menu_config:
                    UI.visualTreeAsset = visualTreeAssets[4];
                    break;
                case TipoNodo.creditos:
                    UI.visualTreeAsset = visualTreeAssets[5];
                    break;

            }
            if (currentNodo.tipoNodo != TipoNodo.historiaPresentacion)
            {
                nombre = UI.rootVisualElement.Q<Label>("nombre");

            }
            label = UI.rootVisualElement.Q<Label>("contenido");
            foreach (Boton boton in currentNodo.botones)
            {
                Button button = new Button();
                button.text = boton.nombre;
                button.AddToClassList(boton.tipoBoton == TipoBoton.Eleccion ? "boton-secundario-pequeno" : "boton-primario-pequeno");
                UI.rootVisualElement.Q<VisualElement>(boton.tipoBoton == TipoBoton.Eleccion ? "opciones" : "botones").Add(button);
                switch (boton.tipoBoton)
                {
                    case TipoBoton.Salir:
                        button.clickable.clicked += () => CerrarDialogo();


                        break;
                    case TipoBoton.Cerrar:
                        button.clickable.clicked += () => Application.Quit();
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
            if (nombre != null)
            {
                if (currentNodo.esPersonaje && currentNodo.tipoNodo != TipoNodo.historiaPresentacion)
                {
                    nombre.text = currentNodo.personaje;

                }
                else if (currentNodo.tipoNodo == TipoNodo.historiaPresentacion)
                {
                }
                else if (!currentNodo.esPersonaje)
                {
                    nombre.style.display = DisplayStyle.None;
                }
            }

            if (label != null)
            {
                label.text = string.Empty;
                label.text = currentNodo.texto;
                //foreach (char c in currentNodo.texto.ToCharArray())
                //{

                //    if (c == currentNodo.texto[currentLetter])
                //    {
                //        label.text += c;

                //    }
                //    currentLetter++;

                //yield return new WaitForSeconds(textSpeed);
                //}   
            }

        }
    }
    public void AsignarDialogo(string identifier)
    {
        //StopCoroutine(rutina);
        currentDialogue = Array.Find(currentEvent.dialogos, e => e.identifier == identifier);
        currentNodo = currentDialogue.nodos[0];
        TypeLine();
    }
    public void AsignarNodo(int index)
    {
        //StopCoroutine(rutina);
        currentNodo = currentDialogue.nodos[index];
        TypeLine();
    }
    public void CerrarDialogo()
    {
        cinemachine.SetActive(true);
        Destroy(gameObject);
        player.GetComponent<PlayerInput>().ActivateInput();
        expModo.GetComponent<UIDocument>().rootVisualElement.style.display = DisplayStyle.Flex;
    }
}   
