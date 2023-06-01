using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuaVaConMadre : MonoBehaviour
{
    [SerializeField] private Transform player;
	[SerializeField] private PlayerMovement pm;
    [HideInInspector] public bool fuaIsFollowing;
	private float difference = 2f;
	private Vector3 movementAux;

	private void FixedUpdate()
	{
		if (EventHandler.Variables[Variable.sigueARamen] == 1)
		{
			fuaIsFollowing = true;
		}
	}

	void Update()
    {
        if (fuaIsFollowing)
		{
			if (pm.movement.x != 0 || pm.movement.y != 0)
			{
				movementAux = new Vector3(pm.movement.x, 0, pm.movement.z);
			}

			Vector3 targetPosition = new Vector3(player.position.x, player.position.y - 0.8f, player.position.z + difference);
			transform.position = targetPosition;
			Quaternion rotacionDeseada = Quaternion.LookRotation(movementAux);
			transform.rotation = rotacionDeseada;
		}
    }
}
