using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CamMovement : MonoBehaviour
{
    public GameObject Camera;
    private Vector2 LookPos;
    public float Sens = .5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookAround();
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        LookPos = context.ReadValue<Vector2>();
    }
    void LookAround()
    {
        Camera.transform.RotateAround(transform.position, Vector3.up, LookPos.x * Sens);
        Camera.transform.LookAt(transform.position);
    }
}
