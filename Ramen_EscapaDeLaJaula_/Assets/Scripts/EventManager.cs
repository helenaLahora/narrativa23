using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(menuName = "Lista de Dialogos")]
public class EventManager : ScriptableObject
{
    public Evento[] eventos;
     
}

[System.Serializable]
public class Evento
{
    public string identifier;
    public Dialogo[] dialogos;
}

[System.Serializable]
public class Dialogo
{
    public string identifier;
    public Nodo[] nodos;
}
[System.Serializable]

public class Nodo
{
    public TipoNodo tipoNodo;
    public bool esPersonaje;
    public string personaje;
    [TextArea]
    public string texto;
    public Boton[] botones;
    

}
[System.Serializable]

public class Boton
{
    public TipoBoton tipoBoton;
    public string nombre;
    public string siguienteDialogo;
    public UnityEvent accion;

}
public enum TipoNodo
{
    conversacion,
    presentacion,
    eleccion
}
public enum TipoBoton
{
    Salir,
    Continuar,
    Volver,
    Eleccion
}