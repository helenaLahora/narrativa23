using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject[] knifePrefabs; // Array of knife prefabs
    public Transform[] spawnPoints; // Array of spawn points
    public float spawnInterval = 2f; // Interval between knife spawns
    public float knifeLifetime = 5f; // Time until knives disappear
    public float knifeSpeed = 5f; // Speed at which knives fall
    public float knifeWeight = 10f; // Weight of the knives
    public int knifeCount = 1; // Number of knives to spawn

    private float timer = 0f; // Timer to track spawn interval

    private void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        // Check if it's time to spawn knives
        if (timer >= spawnInterval)
        {
            // Spawn the specified number of knives
            for (int i = 0; i < knifeCount; i++)
            {
                // Choose a random knife prefab from the array
                int randomKnifeIndex = Random.Range(0, knifePrefabs.Length);
                GameObject selectedKnifePrefab = knifePrefabs[randomKnifeIndex];

                // Choose a random spawn point from the array
                int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
                Transform selectedSpawnPoint = spawnPoints[randomSpawnIndex];

                // Instantiate the selected knife prefab at the selected spawn point with rotation -90 degrees on the Z-axis
                GameObject spawnedKnife = Instantiate(selectedKnifePrefab, selectedSpawnPoint.position, Quaternion.Euler(0f, 0f, -90f));

                // Set the object where the script is attached as the parent of the spawned knife
                spawnedKnife.transform.SetParent(transform);

                // Add Rigidbody component to the spawned knife
                Rigidbody knifeRigidbody = spawnedKnife.GetComponent<Rigidbody>();
                if (knifeRigidbody == null)
                {
                    knifeRigidbody = spawnedKnife.AddComponent<Rigidbody>();
                }
                knifeRigidbody.useGravity = true;
                knifeRigidbody.isKinematic = false;
                knifeRigidbody.velocity = Vector3.down * knifeSpeed;

                // Set the mass of the knife's Rigidbody
                knifeRigidbody.mass = knifeWeight;

                // Destroy the spawned knife after the specified lifetime
                Destroy(spawnedKnife, knifeLifetime);
            }

            // Reset the timer
            timer = 0f;
        }
    }
}