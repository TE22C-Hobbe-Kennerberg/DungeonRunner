using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [NonSerialized] public RangedWeaponStats stats;
    private Vector3 startLocation;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startLocation = transform.position;
       // transform.localEulerAngles = new Vector3(0, 0, 45);
        rb.velocity = transform.up * stats.projectileSpeed;
    }

    void Update()
    {
        Debug.Log(transform.up);
        if(Vector3.Distance(startLocation, transform.position) > stats.range)
        {
            Destroy(gameObject);
        }
    }
}
