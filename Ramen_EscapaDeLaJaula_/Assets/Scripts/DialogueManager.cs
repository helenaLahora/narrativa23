using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Lista de Dialogos")]
public class DialogueManager : ScriptableObject
{
    public Dialogo[] Dialogos;
     
}
[System.Serializable]
public class Dialogo
{
    public string Identifier;
    public Frase[] Frases;
}
[System.Serializable]

public class Frase
{
    public string Personaje;
    [TextArea]
    public string Texto;
}