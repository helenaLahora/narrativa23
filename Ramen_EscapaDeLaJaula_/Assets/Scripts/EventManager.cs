using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

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
    public Accion[] accion;
    public Condicion[] condiciones;
}
[System.Serializable]
public class Accion
{
    public Variable variable;
    public int valor;
    
}
[System.Serializable]
public class Condicion
{
    public Variable variable;
    public Operador operador;
    public int valor;
    [FormerlySerializedAs("Condicion cumplida")]
    public string dialogoTrue;    
    [FormerlySerializedAs("Condicion no cumplida")]
    public string dialogoFalse;
}


public enum TipoNodo
{
    conversacion,
    presentacion,
    eleccion,
    historiaPresentacion,
    menu_config,
    creditos,
    menu_inicio
}
public enum TipoBoton
{
    Salir,
    Continuar,
    Volver,
    Eleccion,
    Condicion,
    Cerrar
}
public enum Variable
{
    Juguetes_completedMission,
    Polvo_completedMission,
    bedroomDoor,
    coin,
    explainedMission,
    collectedObjects,
    bolaEjercicio
}
public enum Operador
{
    igual,
    diferente,
    mayor,
    menor,
    mayor_igual,
    menor_igual
}