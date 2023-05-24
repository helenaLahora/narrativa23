using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fogones : MonoBehaviour
{
    public Material materialActivo;
    public Material materialInactivo;
    public Transform waypoint;
    public float tiempoAlternancia = 1.5f;

    private Renderer objetoRenderer;
    private bool estadoActivo = true;

    private void Start()
    {
        objetoRenderer = GetComponent<Renderer>();
        InvokeRepeating("AlternarEstado", tiempoAlternancia, tiempoAlternancia);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (estadoActivo && other.CompareTag("Player"))
        {
            other.transform.position = waypoint.position;
        }
    }

    private void AlternarEstado()
    {
        estadoActivo = !estadoActivo;

        if (estadoActivo)
        {
            objetoRenderer.material = materialActivo;
        }
        else
        {
            objetoRenderer.material = materialInactivo;
        }
    }
}