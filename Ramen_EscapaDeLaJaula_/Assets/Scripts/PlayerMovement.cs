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
    [SerializeField] private FirstUI firstUI;
    [HideInInspector] public bool menu = false;
    [SerializeField] private PlayerDetection pd;

    private Coroutine speedBoostCoroutine; // Referencia al coroutine de aumento de velocidad
    private float baseSpeed; // Velocidad base del jugador
    private float currentSpeed; // Velocidad actual del jugador
    public float speedBoostDuration = 5f; // Duración del aumento de velocidad

    // Start is called before the first frame update
    void Start()
    {
        Cc = GetComponent<CharacterController>();

        baseSpeed = speed;
        currentSpeed = baseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        verticalSpeed += gravity * Time.deltaTime;
        //Debug.Log(Cc.isGrounded);
        
        Movement();


        //Debug.Log(EventHandler.Variables[Variable.collectedObjects]);

        //ApplyGravity();

        //Debug.Log("Velocidad del jugador: " + currentSpeed);
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
        movement = forward * raw_movement.y * speed + right * raw_movement.x * speed;
        //movement = new Vector3(raw_movement.x,0,raw_movement.y);
        movement.y = verticalSpeed;

        Cc.Move(movement * Time.deltaTime);
        if (movement.x != 0)
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

    public void OnEscapeMenu(InputAction.CallbackContext context)
    {
        menu = !menu;
        if (menu)
        {
            firstUI.Menu();
        }
    }

    // Método para aumentar la velocidad de movimiento
    public void IncreaseSpeed(float amount)
    {
        if (speedBoostCoroutine != null)
        {
            StopCoroutine(speedBoostCoroutine); // Detener el coroutine anterior si existe
        }

        currentSpeed = baseSpeed + amount;
        speedBoostCoroutine = StartCoroutine(ResetSpeedAfterDelay(speedBoostDuration));
    }

    // Método para restablecer la velocidad de movimiento
    public void ResetSpeed()
    {
        currentSpeed = baseSpeed;
        if (speedBoostCoroutine != null)
        {
            StopCoroutine(speedBoostCoroutine); // Detener el coroutine anterior si existe
        }
    }

    // Coroutine para restablecer la velocidad después de un retraso
    private IEnumerator ResetSpeedAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ResetSpeed();
    }
}