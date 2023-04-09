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
    private Vector3 movement;
    private float verticalSpeed;
    private float gravity = -20f;
    public float JumpForce = 10f;
    // Start is called before the first frame update
    void Start()
    {
        Cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalSpeed += gravity * Time.deltaTime;
        //Debug.Log(Cc.isGrounded);
        Movement();

        //Debug.Log(EventHandler.Variables[Variable.collectedObjects]);

        //ApplyGravity();


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
        movement.y = verticalSpeed;
        //movement.y += gravity;
        //if (Jump && Cc.isGrounded)
        //{
        //    movement.y += JumpForce ;
        //}
        //else if(Jump==false && Cc.isGrounded)
        //{
        //    movement.y = 0f;    
        //}


        Cc.Move(movement * Time.deltaTime);
        if(movement.x != 0)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(-movement.z, 0, movement.x));

        }
        if (Cc.isGrounded)
        {
            verticalSpeed = 0f;
            movement.y = 0f;
            
            
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
            if (Cc.isGrounded)
            {
                verticalSpeed += JumpForce;

            }

        }


        

    }
}

