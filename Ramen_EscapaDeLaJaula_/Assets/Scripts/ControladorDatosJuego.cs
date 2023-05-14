using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Cinemachine;

public class ControladorDatosJuego : MonoBehaviour
{
	public GameObject jugador;
	public GameObject cam;
	public CinemachineFreeLook freeLook;
	public string archivoDeGuardado;
	private DatosJuego datosJuego = new DatosJuego();

	private Vector3 camPos;

	private void Awake()
	{
		archivoDeGuardado = Application.dataPath + "/datosJuego.json";

		jugador = GameObject.FindGameObjectWithTag("Ramen");
		cam = GameObject.FindGameObjectWithTag("MainCamera");
		
	}

	private void FixedUpdate()
	{
		camPos = freeLook.State.FinalPosition;

	}

	public void GuardarDatos()
	{
		datosJuego.playerPosition = jugador.transform.position;
		datosJuego.cameraPosition = cam.transform.position;
		datosJuego.cinemachinePosition = camPos;

		string cadenaJSON = JsonUtility.ToJson(datosJuego);

		File.WriteAllText(archivoDeGuardado, cadenaJSON);

		Debug.Log("Archivo guardado correctamente");
	}

	public void CargarDatos()
	{
		if (File.Exists(archivoDeGuardado))
		{
			string contenido = File.ReadAllText(archivoDeGuardado);
			datosJuego = JsonUtility.FromJson<DatosJuego>(contenido);

			//Debug.Log("Posicion jugador : " + datosJuego.playerPosition);
			//Debug.Log("Posicion camara : " + datosJuego.cameraPosition);

			jugador.transform.position = datosJuego.playerPosition;
			cam.transform.position = datosJuego.cameraPosition;
			freeLook.ForceCameraPosition(datosJuego.cinemachinePosition, Quaternion.identity);
		}
		else
		{
			Debug.Log("El archivo no existe");
		}
	}

}
