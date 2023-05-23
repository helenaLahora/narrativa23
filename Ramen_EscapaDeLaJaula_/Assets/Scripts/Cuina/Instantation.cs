using UnityEngine;

public class Instantation : MonoBehaviour
{
    private Rigidbody knifeRigidbody;

    private void Start()
    {
        knifeRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Aqu� puedes ajustar la velocidad de ca�da del cuchillo
        float fallSpeed = 10f;
        knifeRigidbody.AddForce(Vector3.down * fallSpeed, ForceMode.Acceleration);
    }
}
