using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1;
    [SerializeField] private float dashForce = 2;
    [SerializeField] private float rotationSpeed = 2;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();
        Rotation();
    }

    void Movement()
    {
        // Gets player input.
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        float inputVertical = Input.GetAxisRaw("Vertical");
        // Normalizes the vector to make all movement in all directions the same speed.
        Vector3 input = new Vector3(inputHorizontal, inputVertical, 0).normalized;



        transform.position += input * movementSpeed * Time.deltaTime;

        // Increases movmentSpeed for this frame if player is dashing.
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            rb.AddForce(input * dashForce);
        }

        // Makes the camera follow the player.
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -15);
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
