using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f;
    private Vector2 raw_movement;
    private CharacterController Cc;
    public float gravity = -9.8f;
    public Camera cam;
    Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        Cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        ApplyGravity();
        Movement();
        
    }

    void OnMove(InputValue value)
    {
        raw_movement = value.Get<Vector2>();
    }

    void Movement()
    {
        Vector3 forward = cam.transform.forward;
        Vector3 right = cam.transform.right;
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();
        movement = forward * raw_movement.y * speed+ right * raw_movement.x * speed;
        movement.y = gravity;
        Cc.Move(movement * Time.deltaTime);


    }
    void ApplyGravity()
    {
        if (!Cc.isGrounded)
        {
            
            gravity = -9.8f; 

        }
        else
        {
            gravity = 0;
           
        }
       
       

    }
}
