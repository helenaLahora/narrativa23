using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class CamMovement : MonoBehaviour
{
    public GameObject Camera;
    private Vector2 LookPos;
    public float rotationSens = .5f;
    private Vector3 position;
    public Transform camRotator;
    private GameObject CamParent;
    private Vector3 LastPosition;
    private Vector3 difference;
    private float Xrotation;

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
        Xrotation = LookPos.x * rotationSens * Time.deltaTime;

        if (Mathf.Abs(LookPos.x) > 0)
        {
            CamParent.transform.RotateAround(transform.position, Vector3.up, Xrotation);
            CamParent.transform.rotation = Quaternion.identity;

        }

        

        Camera.transform.LookAt(transform.position);

    }
}
