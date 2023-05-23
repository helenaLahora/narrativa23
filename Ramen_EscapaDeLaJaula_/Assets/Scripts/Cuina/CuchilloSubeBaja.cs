using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuchilloSubeBaja : MonoBehaviour
{
    private float originalHeight;
    private bool isAscending = true;
    public float heightIncrease = 2f;
    public float speed = 1f;

    private void Start()
    {
        originalHeight = transform.position.y;
    }

    private void Update()
    {
        float newY = transform.position.y;

        if (isAscending)
        {
            newY += heightIncrease * Time.deltaTime * speed;

            if (newY >= originalHeight + heightIncrease)
            {
                newY = originalHeight + heightIncrease;
                isAscending = false;
            }
        }
        else
        {
            newY -= heightIncrease * Time.deltaTime * speed;

            if (newY <= originalHeight)
            {
                newY = originalHeight;
                isAscending = true;
            }
        }

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}