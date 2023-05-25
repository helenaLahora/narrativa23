using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nevera : MonoBehaviour
{
    public Material originalMaterial; // Original material for the player
    public Material speedBoostMaterial; // Material for the speed boost
    public GameObject playerObject; // Reference to the player's GameObject
    public Renderer playerRenderer; // Reference to the player's Renderer component
    private Material currentMaterial; // Current material applied to the player

    private PlayerMovement playerMovement; // Reference to the PlayerMovement script

    private void Start()
    {
        playerMovement = playerObject.GetComponent<PlayerMovement>(); // Get the PlayerMovement component
        currentMaterial = originalMaterial; // Set initial material
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ApplySpeedBoost());
            ChangePlayerColor();
        }
    }

    private IEnumerator ApplySpeedBoost()
    {
        playerMovement.enabled = false; // Disable player movement by disabling the PlayerMovement component
        yield return new WaitForSeconds(5f); // Wait for the specified duration
        playerMovement.enabled = true; // Enable player movement by enabling the PlayerMovement component
        ResetPlayerColor();
    }

    private void ChangePlayerColor()
    {
        if (playerRenderer != null)
        {
            playerRenderer.material = speedBoostMaterial;
            currentMaterial = speedBoostMaterial;
        }
        else
        {
            Debug.LogWarning("No playerRenderer component assigned in the Inspector.");
        }
    }

    private void ResetPlayerColor()
    {
        if (playerRenderer != null)
        {
            playerRenderer.material = originalMaterial;
            currentMaterial = originalMaterial;
        }
        else
        {
            Debug.LogWarning("No playerRenderer component assigned in the Inspector.");
        }
    }
}