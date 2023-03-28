using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CamMovement : MonoBehaviour
{
    public GameObject Camera;
    private Vector2 LookPos;
    public Vector3 point;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookAround();
    }
    void OnLook(InputValue value)
    {
        LookPos = value.Get<Vector2>();
    }
    void LookAround()
    {
        Camera.transform.RotateAround(transform.position, Vector3.up, LookPos.x);
        Camera.transform.LookAt(transform.position);
        point = new Vector3 (transform.position.x + LookPos.x, transform.position.y, transform.position.z + LookPos.y);
    }
}
