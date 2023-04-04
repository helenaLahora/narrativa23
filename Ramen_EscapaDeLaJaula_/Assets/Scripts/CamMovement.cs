using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class CamMovement : MonoBehaviour
{
    public GameObject Camera;
    private Vector2 LookPos;
    public float Sens = .5f;
    public Vector3 difference;
    private Vector3 LastPosition;
    public Transform camRotator;
    private GameObject CamParent;
    private Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        CamParent = Camera.transform.parent.gameObject;
        LastPosition = camRotator.position;
        position = Camera.transform.position;
        CamParent.transform.position = position;

    }

    // Update is called once per frame
    void Update()
    {
        camRotator.rotation = Quaternion.identity;


        difference = camRotator.position - LastPosition;

        LookAround();
        CamParent.transform.Translate(difference.x, difference.y, difference.z);

        LastPosition = camRotator.position;
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
