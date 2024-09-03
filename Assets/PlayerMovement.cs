using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1;
    [SerializeField] private float dashDistance = 2;

    void Update()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");
        Vector3 input = new Vector3(inputHorizontal, inputVertical, 0);
        transform.position += input * movementSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position += input.normalized * dashDistance;
        }
    }
}
