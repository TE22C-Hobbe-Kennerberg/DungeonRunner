using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1;
    [SerializeField] private float dashDistance = 2;
    [SerializeField] private float rotationSpeed = 2;


    void Update()
    {
        Movement();
        Rotation();
    }

    void Movement()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");
        Vector3 input = new Vector3(inputHorizontal, inputVertical, 0);
        transform.position += input * movementSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            transform.position += input.normalized * dashDistance;
        }
    }

    void Rotation()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localEulerAngles = transform.localEulerAngles - Vector3.forward * rotationSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localEulerAngles = transform.localEulerAngles + Vector3.forward * rotationSpeed * Time.deltaTime;
        }
    }
}
