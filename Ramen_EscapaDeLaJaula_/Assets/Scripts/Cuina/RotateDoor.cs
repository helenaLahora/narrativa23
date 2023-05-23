using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDoor : MonoBehaviour
{
    public float minRotation = 45f;  // Ángulo mínimo de rotación
    public float maxRotation = 100f; // Ángulo máximo de rotación
    public float rotationSpeed = 50f; // Velocidad de rotación

    private float currentRotation; // Ángulo de rotación actual
    private bool increasingRotation = true; // Indicador de aumento de rotación

    private void Start()
    {
        // Inicializar el ángulo de rotación actual
        currentRotation = minRotation;
        transform.rotation = Quaternion.Euler(0f, currentRotation, 0f);
    }

    private void Update()
    {
        // Rotar el objeto continuamente
        if (increasingRotation)
        {
            currentRotation += rotationSpeed * Time.deltaTime;

            // Si el ángulo de rotación actual supera el máximo, invertir la dirección
            if (currentRotation >= maxRotation)
            {
                currentRotation = maxRotation;
                increasingRotation = false;
            }
        }
        else
        {
            currentRotation -= rotationSpeed * Time.deltaTime;

            // Si el ángulo de rotación actual cae por debajo del mínimo, invertir la dirección
            if (currentRotation <= minRotation)
            {
                currentRotation = minRotation;
                increasingRotation = true;
            }
        }

        // Aplicar la rotación al objeto
        transform.rotation = Quaternion.Euler(0f, currentRotation, 0f);
    }
}