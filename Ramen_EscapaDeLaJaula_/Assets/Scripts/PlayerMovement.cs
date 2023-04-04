using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f;
    private Vector2 raw_movement;
    private CharacterController Cc;
    public Camera cam;
    Vector3 movement;
    public float gravity;
    public float JumpForce = 10f, jumpcounter=0;
    private bool Jump = false;
    // Start is called before the first frame update
    void Start()
    {
        Cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        ApplyGravity();


    }

    public void OnMove(InputAction.CallbackContext context)
    {
        raw_movement = context.ReadValue<Vector2>();
    }

    void Movement()
    {
        Vector3 forward = cam.transform.forward;
        Vector3 right = cam.transform.right;
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();
        movement = forward* raw_movement.y * speed + right * raw_movement.x * speed;
        if (Jump && Cc.isGrounded)
        {
            movement.y += JumpForce ;
        }
        else if(!Jump && !Cc.isGrounded)
        {
            movement.y += gravity;
        }
        Cc.Move(movement * Time.deltaTime);

        if (Cc.isGrounded)
        {

            jumpcounter = 0;
            
        }





    }
    void ApplyGravity()
    {
        if (!Cc.isGrounded)
        {

            gravity = -9.8f;
            movement.y += gravity;
            
        }
        else
        {
           gravity = 0;
         
        }

    }
    public void OnJump(InputAction.CallbackContext context)
	{
        if (context.started)
        {
            Jump = true;
            if (Cc.isGrounded)
            {
                jumpcounter = 0;

            }
            if (jumpcounter < 1)
            {
                movement.y += JumpForce;

            }
            jumpcounter++;
        }
        if (context.canceled || !Cc.isGrounded){
            Jump = false;

        }

        

    }
}

