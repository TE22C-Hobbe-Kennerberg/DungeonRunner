using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Health healthScript;
    [SerializeField] private float movementSpeed = 1;

    void Start()
    {
        healthScript = GetComponent<Health>();
    }

    void Update()
    {
        // Move towards player.
        Vector3 playerPos = GameObject.Find("Player").transform.position;
        Vector3 movement = playerPos - transform.position;
        movement = movement.normalized * movementSpeed;
        transform.position += movement;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}