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

        Cc.Move(new Vector3(raw_movement.x * speed * Time.deltaTime, gravity * Time.deltaTime, raw_movement.y * speed * Time.deltaTime));
    }
    void ApplyGravity()
    {
        if (!Cc.isGrounded)
        {
            Debug.Log("volan2");
            gravity = -9.8f; 

        }
        else
        {
            gravity = 0;
            Debug.Log("Hola");
        }
       
       

    }
}
