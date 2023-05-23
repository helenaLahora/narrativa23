using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerUniqueSpawnPoint : MonoBehaviour
{
    public GameObject[] Prefabs; // Array of prefabs
    public Transform spawnPoint; // Single spawn point
    public float spawnInterval = 2f; // Interval between spawns
    public float Lifetime = 5f; // Time until items disappear
    public float Speed = 5f; // Speed at which items fall
    public float Weight = 10f; // Weight of the items
    public int count = 1; // Number of items to spawn

    private float timer = 0f; // Timer to track spawn interval

    private void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        // Check if it's time to spawn items
        if (timer >= spawnInterval)
        {
            // Spawn the specified number of items
            for (int i = 0; i < count; i++)
            {
                // Choose a random prefab from the array
                int randomItemIndex = Random.Range(0, Prefabs.Length);
                GameObject selectedItemPrefab = Prefabs[randomItemIndex];

                // Instantiate the selected prefab at the spawn point with rotation -90 degrees on the Z-axis
                GameObject spawnedItem = Instantiate(selectedItemPrefab, spawnPoint.position, Quaternion.Euler(0f, 0f, -90f));

                // Set the object where the script is attached as the parent of the spawned item
                spawnedItem.transform.SetParent(transform);

                // Add Rigidbody component to the spawned item
                Rigidbody itemRigidbody = spawnedItem.GetComponent<Rigidbody>();
                if (itemRigidbody == null)
                {
                    itemRigidbody = spawnedItem.AddComponent<Rigidbody>();
                }
                itemRigidbody.useGravity = true;
                itemRigidbody.isKinematic = false;
                itemRigidbody.velocity = Vector3.down * Speed;

                // Set the mass of the item's Rigidbody
                itemRigidbody.mass = Weight;

                // Destroy the spawned item after the specified lifetime
                Destroy(spawnedItem, Lifetime);
            }

            // Reset the timer
            timer = 0f;
        }
    }
}
