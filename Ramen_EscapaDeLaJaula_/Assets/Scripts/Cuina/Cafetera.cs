using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cafetera : MonoBehaviour
{
    public float speedBoostAmount = 2f; // Amount of speed boost
    public float speedBoostDuration = 5f; // Duration of the speed boost
    public Color speedBoostColor = Color.red; // Color of the speed boost
    public GameObject playerObject; // Reference to the player's GameObject

    private PlayerMovement playerMovement; // Reference to the PlayerMovement script

    private void Start()
    {
        // Get the PlayerMovement component from the player's GameObject
        playerMovement = playerObject.GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("La cafetera ha entrado en contacto con el jugador.");

            StartCoroutine(ApplySpeedBoost());
            StartCoroutine(ResetSpeed());
            ChangePlayerColor();
        }
    }

    private IEnumerator ApplySpeedBoost()
    {
        playerMovement.IncreaseSpeed(speedBoostAmount);
        yield return new WaitForSeconds(speedBoostDuration);
        playerMovement.ResetSpeed();
    }

    private IEnumerator ResetSpeed()
    {
        yield return new WaitForSeconds(speedBoostDuration); // Wait for the specified duration
        ResetPlayerColor();
        playerMovement.ResetSpeed(); // Reset the player's speed
        //Debug.Log("El aumento de velocidad ha terminado. La velocidad del jugador ha vuelto a la normalidad.");
    }

    private void ChangePlayerColor()
    {
        Renderer[] playerRenderers = playerObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in playerRenderers)
        {
            foreach (Material material in renderer.materials)
            {
                material.color = speedBoostColor;
            }
        }
    }

    private void ResetPlayerColor()
    {
        Renderer[] playerRenderers = playerObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in playerRenderers)
        {
            foreach (Material material in renderer.materials)
            {
                material.color = Color.white;
            }
        }
    }
}