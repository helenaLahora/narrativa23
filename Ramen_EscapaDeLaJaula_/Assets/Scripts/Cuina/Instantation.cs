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
        // Aquí puedes ajustar la velocidad de caída del cuchillo
        float fallSpeed = 10f;
        knifeRigidbody.AddForce(Vector3.down * fallSpeed, ForceMode.Acceleration);
    }
}
