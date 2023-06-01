using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class SalchichaMax : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI dialogoSalchicha;
	[SerializeField] private GameObject salchichaMax;
	[SerializeField] private GameObject colliderPato;
	private bool isInRange;

	private void Start()
	{
		EventHandler.Variables[Variable.salchicha] = 1;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player") && EventHandler.Variables[Variable.salchicha] == 1)
		{
			dialogoSalchicha.gameObject.SetActive(true);
			isInRange = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player") && EventHandler.Variables[Variable.salchicha] == 1)
		{
			dialogoSalchicha.gameObject.SetActive(false);
			isInRange = false;
		}
	}

	private void OnInteract()
	{
		if (isInRange && EventHandler.Variables[Variable.salchicha] == 1)
		{
			EventHandler.Variables[Variable.salchicha] = 0;
			salchichaMax.SetActive(true);
			dialogoSalchicha.gameObject.SetActive(false);
			colliderPato.SetActive(false);
		}
	}
}
