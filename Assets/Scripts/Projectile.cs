using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [NonSerialized] public float damage;
    [NonSerialized] public float speed;
    [NonSerialized] public float range;

    private Vector3 startLocation;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startLocation = transform.position;
        // transform.localEulerAngles = new Vector3(0, 0, 45);
        rb.velocity = transform.up * speed;
    }

    void Update()
    {
        if (Vector3.Distance(startLocation, transform.position) > range)
        {
            Destroy(gameObject);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name != "Projectile(Clone)")
        {
            Destroy(gameObject);
        }

    }
}

