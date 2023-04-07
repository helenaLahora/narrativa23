using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements; 
public class UIHANDLE : MonoBehaviour
{
    private UIDocument UI;
    public Label label, nombre;
    public EventManager eventManager;
    private Dialogo currentDialogue;
    public float textSpeed =1f;
    private Button salir, continuar;

    // Start is called before the first frame update
    private void Awake()
    {
        UI = GetComponent<UIDocument>();
        if (UI != null)
        {
            continuar = UI.rootVisualElement.Q<Button>("continuar");
            salir = UI.rootVisualElement.Q<Button>("salir");

            salir.clickable.clicked += () => Destroy(gameObject);
            label = UI.rootVisualElement.Q<Label>("contenido");
            nombre = UI.rootVisualElement.Q<Label>("nombre");
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartDialogue(string identifier)
    {
        

        currentDialogue = Array.Find(eventManager.eventos[0].dialogos, e => e.identifier == identifier);
        StartCoroutine(TypeLine());
                
    }
    IEnumerator TypeLine()
    {
        foreach (Nodo nodo in currentDialogue.nodos)
        {
            
            label.text = string.Empty;
            nombre.text = nodo.personaje;
            foreach (char c in nodo.texto.ToCharArray())
            {
                label.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }

    }
}   
