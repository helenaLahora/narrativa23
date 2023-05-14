using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardarCargarPartida : MonoBehaviour
{

	ControladorDatosJuego controladorDatosJuego;

	private void Start()
	{
		controladorDatosJuego = GetComponent<ControladorDatosJuego>();
	}

	private void OnSave()
	{
		controladorDatosJuego.GuardarDatos();
	}

	private void OnLoad()
	{
		controladorDatosJuego.CargarDatos();
	}
}
