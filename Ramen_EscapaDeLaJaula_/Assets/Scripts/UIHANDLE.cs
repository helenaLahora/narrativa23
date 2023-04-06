using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements; 
public class UIHANDLE : MonoBehaviour
{
    public UIDocument UI;
    public Label label, nombre;

    public DialogueManager dialogueManager;
    private Dialogo currentDialogue;
    public float textSpeed =1f;

    // Start is called before the first frame update
    void Start()
    {
        label = UI.rootVisualElement.Q<Label>("contenido");
       nombre = UI.rootVisualElement.Q<Label>("nombre");
        label.text = "";
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartDialogue(string identifier)
    {
        
        currentDialogue = Array.Find(dialogueManager.Dialogos, e => e.Identifier == identifier);
        
        StartCoroutine(TypeLine());
                
    }
    IEnumerator TypeLine()
    {
        foreach (var frase in currentDialogue.Frases)
        {
            label.text = "";

            nombre.text = frase.Personaje;
            foreach (char c in frase.Texto.ToCharArray())
            {
                
                label.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }

    }
}   
