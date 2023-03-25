using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public float speedDivider = 5f;
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
        Movement();
        
    }

    void OnMove(InputValue value)
    {
        raw_movement = value.Get<Vector2>();
    }

    void Movement()
    {

        transform.Translate(raw_movement.x / speedDivider, 0, raw_movement.y / speedDivider);
        if (!Cc.isGrounded)
        {
            //ApplyGravity();
            Debug.Log("Volan2");

        }
        else
        {
            Debug.Log("Hola");
        }

    }
    void ApplyGravity()
    {

            transform.Translate(0,gravity,0);
        
    }
}
